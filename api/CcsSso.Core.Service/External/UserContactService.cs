using CcsSso.DbModel.Entity;
using CcsSso.Domain.Constants;
using CcsSso.Domain.Contracts;
using CcsSso.Domain.Contracts.External;
using CcsSso.Domain.Dtos.External;
using CcsSso.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CcsSso.Service.External
{
  public class UserContactService : IUserContactService
  {
    private readonly IDataContext _dataContext;
    private readonly IContactsHelperService _contactsHelper;
    public UserContactService(IDataContext dataContext, IContactsHelperService contactsHelper)
    {
      _dataContext = dataContext;
      _contactsHelper = contactsHelper;
    }

    /// <summary>
    /// Create a user contact
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contactInfo"></param>
    /// <returns></returns>
    public async Task<int> CreateUserContactAsync(int userId, ContactInfo contactInfo)
    {
      _contactsHelper.ValidateContacts(contactInfo.Contacts);

      var user = await _dataContext.User
        .Include(u => u.Party.Person)
        .FirstOrDefaultAsync(u => u.Id == userId);

      if (user != null)
      {
        var contactPointReasonId = await _contactsHelper.GetContactPointReasonIdAsync(contactInfo.ContactReason);

        #region Create new contact point for person with party
        var partyTypes = await _dataContext.PartyType.Where(pt => pt.PartyTypeName == PatyType.NonUser || pt.PartyTypeName == PatyType.User).ToListAsync();
        var personPartyTypeId = partyTypes.FirstOrDefault(t => t.PartyTypeName == PatyType.NonUser).Id;
        var userPartyTypeId = partyTypes.FirstOrDefault(t => t.PartyTypeName == PatyType.User).Id;

        // Create the contact point with contact details including the person details, having the party type of NON_USER
        var (firstName, lastName) = _contactsHelper.GetContactPersonNameTuple(contactInfo.Contacts);

        var person = new Person
        {
          FirstName = firstName,
          LastName = lastName,
          OrganisationId = user.Party.Person.OrganisationId
        };

        var party = new Party
        {
          PartyTypeId = personPartyTypeId,
          Person = person,
          ContactPoints = new List<ContactPoint>()
        };

        var contactPoint = new ContactPoint
        {
          Party = party,
          PartyTypeId = personPartyTypeId,
          ContactPointReasonId = contactPointReasonId,
          ContactDetail = new ContactDetail
          {
            EffectiveFrom = DateTime.UtcNow
          }
        };
        await _contactsHelper.AssignVirtualContactsToContactPointAsync(contactInfo.Contacts, contactPoint);

        _dataContext.ContactPoint.Add(contactPoint);
        await _dataContext.SaveChangesAsync();
        #endregion

        #region Add new contact point with created contact details
        // Link the created contact details to user by adding a contact point with a party type of USER
        var userContactPoint = new ContactPoint
        {
          PartyId = user.Party.Id,
          PartyTypeId = userPartyTypeId,
          ContactPointReasonId = contactPointReasonId,
          ContactDetailId = contactPoint.ContactDetailId
        };
        _dataContext.ContactPoint.Add(userContactPoint);
        await _dataContext.SaveChangesAsync();
        #endregion

        return userContactPoint.Id;
      }
      else
      {
        throw new ResourceNotFoundException();
      }
    }

    /// <summary>
    /// Delete a user contact
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contactId"></param>
    /// <returns></returns>
    public async Task DeleteUserContactAsync(int userId, int contactId)
    {
      var deletingContact = await _dataContext.ContactPoint.Where(c => c.Id == contactId &&
        c.Party.User.Id == userId)
        .Include(c => c.ContactDetail).ThenInclude(cd => cd.VirtualAddresses)
        .FirstOrDefaultAsync();

      if (deletingContact != null)
      {
        deletingContact.IsDeleted = true;
        deletingContact.ContactDetail.IsDeleted = true;

        deletingContact.ContactDetail.VirtualAddresses.ForEach((virtualAddress) =>
        {
          virtualAddress.IsDeleted = true;
        });

        await _dataContext.SaveChangesAsync();
      }
    }

    /// <summary>
    /// Get contact details of a user's contact
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contactId"></param>
    /// <returns></returns>
    public async Task<UserContactInfo> GetUserContactAsync(int userId, int contactId)
    {
      // First get the relevant contact point by id
      var contactPoint = await _dataContext.ContactPoint
        .Where(c => !c.IsDeleted && !c.ContactDetail.IsDeleted && c.Id == contactId && c.Party.User.Id == userId)
        .FirstOrDefaultAsync();

      if (contactPoint != null)
      {
        // Get the exact contact details with person details, party type (NON_USER)
        var contact = await _dataContext.ContactPoint
        .Where(c => !c.IsDeleted && c.ContactDetailId == contactPoint.ContactDetailId
          && c.PartyType.PartyTypeName == PatyType.NonUser)
        .Include(c => c.Party.Person).ThenInclude(p => p.Organisation)
        .Include(c => c.ContactPointReason)
        .Include(c => c.ContactDetail.VirtualAddresses).ThenInclude(v => v.VirtualAddressType)
        .FirstOrDefaultAsync();

        if (contact != null)
        {
          var contactInfo = new UserContactInfo
          {
            ContactId = contactPoint.Id,
            UserId = userId,
            ContactReason = contact.ContactPointReason.Name,
            Contacts = new List<Contact>()
          };

          if (contact.Party.Person != null)
          {
            contactInfo.OrganisationId = contact.Party.Person.Organisation.CiiOrganisationId;
            var virtualContact = new Contact
            {
              ContactName = VirtualContactTypeName.Name,
              ContactValue = $"{contact.Party.Person.FirstName} {contact.Party.Person.LastName}"
            };

            contactInfo.Contacts.Add(virtualContact);
          }

          if (contact.ContactDetail.VirtualAddresses != null)
          {
            foreach (var virtualAddress in contact.ContactDetail.VirtualAddresses)
            {
              var virtualContact = new Contact
              {
                ContactName = virtualAddress.VirtualAddressType.Name,
                ContactValue = virtualAddress.VirtualAddressValue
              };

              contactInfo.Contacts.Add(virtualContact);
            }
          }

          return contactInfo;
        }
      }

      throw new ResourceNotFoundException();
    }

    /// <summary>
    /// Get list of contact for a user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<UserContactInfo>> GetUserContactsListAsync(int userId, string contactType = null)
    {
      List<UserContactInfo> contactInfos = new List<UserContactInfo>();

      var user = await _dataContext.User.FirstOrDefaultAsync(u => u.Id == userId);

      if (user == null)
      {
        throw new ResourceNotFoundException();
      }

      // Get the user's contact points with party type USER
      var userContactPoints = await _dataContext.ContactPoint
        .Where(c => !c.IsDeleted && !c.ContactDetail.IsDeleted && c.Party.User.Id == userId && c.PartyType.PartyTypeName == PatyType.User &&
          (contactType == null || c.ContactPointReason.Name == contactType))
        .ToListAsync();

      if (userContactPoints.Any())
      {
        var userContactDetailsIds = userContactPoints.Select(u => u.ContactDetailId).ToList();

        // Get the contact details information for the user's contact points by filtering party type NON_USER
        var contacts = await _dataContext.ContactPoint
        .Where(c => !c.IsDeleted && userContactDetailsIds.Contains(c.ContactDetailId) && c.PartyType.PartyTypeName == PatyType.NonUser)
        .Include(c => c.Party.Person).ThenInclude(p => p.Organisation)
        .Include(c => c.ContactPointReason)
        .Include(c => c.ContactDetail.VirtualAddresses).ThenInclude(v => v.VirtualAddressType)
        .ToListAsync();

        foreach (var contact in contacts)
        {
          var contactInfo = new UserContactInfo
          {
            ContactId = userContactPoints.FirstOrDefault(cp => cp.ContactDetailId == contact.ContactDetailId).Id,
            UserId = userId,
            ContactReason = contact.ContactPointReason.Name,
            Contacts = new List<Contact>()
          };

          if (contact.Party.Person != null)
          {
            contactInfo.OrganisationId = contact.Party.Person.Organisation.CiiOrganisationId;
            var virtualContact = new Contact
            {
              ContactName = VirtualContactTypeName.Name,
              ContactValue = $"{contact.Party.Person.FirstName} {contact.Party.Person.LastName}"
            };

            contactInfo.Contacts.Add(virtualContact);
          }

          if (contact.ContactDetail.VirtualAddresses != null)
          {
            foreach (var virtualAddress in contact.ContactDetail.VirtualAddresses)
            {
              var virtualContact = new Contact
              {
                ContactName = virtualAddress.VirtualAddressType.Name,
                ContactValue = virtualAddress.VirtualAddressValue
              };

              contactInfo.Contacts.Add(virtualContact);
            }
          }

          contactInfos.Add(contactInfo);
        }
      }

      return contactInfos;
    }

    /// <summary>
    /// Update user contact
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contactId"></param>
    /// <param name="contactInfo"></param>
    /// <returns></returns>
    public async Task UpdateUserContactAsync(int userId, int contactId, ContactInfo contactInfo)
    {
      _contactsHelper.ValidateContacts(contactInfo.Contacts);

      // Get the user's contact point
      var updatingContactPoint = await _dataContext.ContactPoint
      .Where(c => !c.IsDeleted && !c.ContactDetail.IsDeleted && c.Id == contactId && c.Party.User.Id == userId)
      .FirstOrDefaultAsync();

      if (updatingContactPoint != null)
      {

        // Get the relevant contact details and person record for the user's contact points contact details
        var updatingContact = await _dataContext.ContactPoint
          .Where(c => !c.IsDeleted && !c.ContactDetail.IsDeleted && c.ContactDetailId == updatingContactPoint.ContactDetailId
            && c.PartyType.PartyTypeName == PatyType.NonUser)
          .Include(c => c.ContactDetail).ThenInclude(cd => cd.VirtualAddresses)
          .Include(c => c.Party).ThenInclude(p => p.Person)
          .FirstOrDefaultAsync();

        if (updatingContact != null)
        {
          var (firstName, lastName) = _contactsHelper.GetContactPersonNameTuple(contactInfo.Contacts);

          updatingContact.Party.Person.FirstName = firstName;
          updatingContact.Party.Person.LastName = lastName;

          var contactPointReasonId = await _contactsHelper.GetContactPointReasonIdAsync(contactInfo.ContactReason);

          updatingContact.ContactPointReasonId = contactPointReasonId;

          await _contactsHelper.AssignVirtualContactsToContactPointAsync(contactInfo.Contacts, updatingContact);

          await _dataContext.SaveChangesAsync();
        }
        else
        {
          throw new ResourceNotFoundException();
        }
      }
      else
      {
        throw new ResourceNotFoundException();
      }
    }

  }
}
