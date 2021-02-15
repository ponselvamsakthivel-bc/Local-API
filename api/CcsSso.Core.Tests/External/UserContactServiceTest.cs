using AgileIQ.Test.Infrastructure;
using CcsSso.DbModel.Entity;
using CcsSso.Domain.Constants;
using CcsSso.Domain.Contracts;
using CcsSso.Domain.Contracts.External;
using CcsSso.Domain.Dtos;
using CcsSso.Domain.Dtos.External;
using CcsSso.Domain.Exceptions;
using CcsSso.Dtos.Domain.Models;
using CcsSso.Service;
using CcsSso.Service.External;
using CcsSso.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CcsSso.Tests.External
{
  public class UserContactServiceTest
  {
    public class CreateUserContact
    {
      public static IEnumerable<object[]> CorrectContactData =>
            new List<object[]>
            {
                new object[]
                {
                  1,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                },
                new object[]
                {
                  2,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                },
                new object[]
                {
                  3,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                },
                new object[]
                {
                  3,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                }
            };

      [Theory]
      [MemberData(nameof(CorrectContactData))]
      public async Task CreateContactSuccessfully_WhenCorrectData(int userId, ContactInfo contactInfo)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);

          var contactService = ContactService(dataContext);

          var createdContactPointId = await contactService.CreateUserContactAsync(userId, contactInfo);

          var userContactData = await dataContext.ContactPoint.Where(c => c.Id == createdContactPointId)
            .FirstOrDefaultAsync();

          var createdContactData = await dataContext.ContactPoint.Where(c => c.ContactDetailId == userContactData.ContactDetailId
            && c.PartyType.PartyTypeName == PatyType.NonUser)
            .Include(cd => cd.ContactDetail.VirtualAddresses).ThenInclude(v => v.VirtualAddressType)
            .Include(cp => cp.Party).ThenInclude(p => p.Person)
            .FirstOrDefaultAsync();

          Assert.NotNull(createdContactData);
          var name = contactInfo.Contacts.FirstOrDefault(c => c.ContactName == VirtualContactTypeName.Name)?.ContactValue;
          if (!string.IsNullOrEmpty(name))
          {
            var nameArray = name.Split(" ");
            Assert.Equal(nameArray[0], createdContactData.Party.Person.FirstName);
            if (nameArray.Length >= 2)
            {
              Assert.Equal(nameArray[nameArray.Length - 1], createdContactData.Party.Person.LastName);
            }
            else
            {
              Assert.Empty(createdContactData.Party.Person.LastName);
            }
          }
          else
          {
            Assert.Empty(createdContactData.Party.Person.FirstName);
          }
        });
      }

      public static IEnumerable<object[]> ContactDataInvalidUser =>
            new List<object[]>
            {
                new object[]
                {
                  4,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                }
            };

      [Theory]
      [MemberData(nameof(ContactDataInvalidUser))]
      public async Task ThrowsException_WhenUserDoesnotExists(int userId, ContactInfo contactInfo)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);

          var contactService = ContactService(dataContext);

          await Assert.ThrowsAsync<ResourceNotFoundException>(() => contactService.CreateUserContactAsync(userId, contactInfo));
        });
      }
    }

    public class GetUserContact
    {
      [Theory]
      [InlineData(1, 1, 3)]
      public async Task ReturnsCorrectContactsIncludingName(int userId, int contactId, int expectedCount)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactService = ContactService(dataContext);

          var result = await contactService.GetUserContactAsync(userId, contactId);

          Assert.Equal(expectedCount, result.Contacts.Count);

        });
      }

      [Theory]
      [InlineData(1, 10)]
      public async Task ThrowsException_WhenNotExsists(int userId, int contactId)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactService = ContactService(dataContext);

          await Assert.ThrowsAsync<ResourceNotFoundException>(() => contactService.GetUserContactAsync(userId, contactId));

        });
      }
    }

    public class GetUserContactsList
    {

      [Theory]
      [InlineData(1, 2)]
      [InlineData(2, 1)]
      public async Task ReturnsCorrectList(int userId, int expectedCount)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactService = ContactService(dataContext);

          var result = await contactService.GetUserContactsListAsync(userId);

          Assert.Equal(expectedCount, result.Count);

        });
      }

      [Theory]
      [InlineData(4)]
      public async Task ThrowsException_WhenUserNotExsists(int userId)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactService = ContactService(dataContext);

          await Assert.ThrowsAsync<ResourceNotFoundException>(() => contactService.GetUserContactsListAsync(userId));

        });
      }
    }

    public class DeleteUserContact
    {
      [Theory]
      [InlineData(1, 1)]
      public async Task DeleteOrganisationContactSuccessfully(int userId, int deletingContactId)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactService = ContactService(dataContext);

          await contactService.DeleteUserContactAsync(userId, deletingContactId);

          var deletedContact = await dataContext.ContactPoint.FirstOrDefaultAsync(c => c.Id == deletingContactId);
          Assert.True(deletedContact.IsDeleted);
          var user = await dataContext.User.FirstOrDefaultAsync(u => u.Id == userId);
          //Assert.Equal(new List<int> { 2 }, user.PersonContactPointIds);
        });
      }
    }

    public class UpdateUserContact
    {
      public static IEnumerable<object[]> CorrectContactData =>
            new List<object[]>
            {
                new object[]
                {
                  1,
                  1,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                },
                new object[]
                {
                  1,
                  1,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                }
            };

      [Theory]
      [MemberData(nameof(CorrectContactData))]
      public async Task UpdateContactSuccessfully_WhenCorrectData(int userId, int contactId, ContactInfo contactInfo)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);

          var contactService = ContactService(dataContext);

          await contactService.UpdateUserContactAsync(userId, contactId, contactInfo);

          var updatedUserContactData = await dataContext.ContactPoint.Where(c => c.Id == contactId)
            .FirstOrDefaultAsync();

          var updatedContactData = await dataContext.ContactPoint.Where(c => c.ContactDetailId == updatedUserContactData.ContactDetailId
            && c.PartyType.PartyTypeName == PatyType.NonUser)
            .Include(cp => cp.ContactDetail)
            .Include(cd => cd.ContactDetail.VirtualAddresses).ThenInclude(v => v.VirtualAddressType)
            .Include(cp => cp.Party)
            .ThenInclude(p => p.Person)
            .FirstOrDefaultAsync();

          Assert.NotNull(updatedContactData);

          var name = contactInfo.Contacts.FirstOrDefault(c => c.ContactName == VirtualContactTypeName.Name)?.ContactValue;
          if (!string.IsNullOrEmpty(name))
          {
            var nameArray = name.Split(" ");
            Assert.Equal(nameArray[0], updatedContactData.Party.Person.FirstName);
            if (nameArray.Length >= 2)
            {
              Assert.Equal(nameArray[nameArray.Length - 1], updatedContactData.Party.Person.LastName);
            }
            else
            {
              Assert.Empty(updatedContactData.Party.Person.LastName);
            }
          }
          else
          {
            Assert.Empty(updatedContactData.Party.Person.FirstName);
          }
        });
      }

      public static IEnumerable<object[]> ContactDataInvalidUser =>
            new List<object[]>
            {
                new object[]
                {
                  4,
                  3,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                },
                new object[]
                {
                  3,
                  3,
                  DtoHelper.GetContactInfo("OTHER", new List<Contact>{
                    DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                    DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                    DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                  })
                }
            };

      [Theory]
      [MemberData(nameof(ContactDataInvalidUser))]
      public async Task ThrowsException_WhenUserDoesnotExists(int userId, int contactId, ContactInfo contactInfo)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);

          var contactService = ContactService(dataContext);

          await Assert.ThrowsAsync<ResourceNotFoundException>(() => contactService.UpdateUserContactAsync(userId, contactId, contactInfo));
        });
      }
    }

    public static UserContactService ContactService(IDataContext dataContext)
    {
      IContactsHelperService contactsHelperService = new ContactsHelperService(dataContext);
      var service = new UserContactService(dataContext, contactsHelperService);
      return service;
    }

    public static async Task SetupTestDataAsync(IDataContext dataContext)
    {
      dataContext.PartyType.Add(new PartyType { Id = 1, PartyTypeName = "INTERNAL_ORGANISATION" });
      dataContext.PartyType.Add(new PartyType { Id = 2, PartyTypeName = PatyType.NonUser });
      dataContext.PartyType.Add(new PartyType { Id = 3, PartyTypeName = PatyType.User });
      dataContext.VirtualAddressType.Add(new VirtualAddressType { Id = 1, Name = VirtualContactTypeName.Email, Description = "email" });
      dataContext.VirtualAddressType.Add(new VirtualAddressType { Id = 2, Name = VirtualContactTypeName.Phone, Description = "phone" });
      dataContext.ContactPointReason.Add(new ContactPointReason { Id = 1, Name = "OTHER", Description = "Other" });
      dataContext.ContactPointReason.Add(new ContactPointReason { Id = 2, Name = "SHIPPING", Description = "Shipping" });
      dataContext.IdentityProvider.Add(new IdentityProvider { Id = 1, IdpName = "IDP", IdpUri = "IDP" });

      dataContext.Party.Add(new Party { Id = 1, PartyTypeId = 1 });
      dataContext.Organisation.Add(new Organisation { Id = 1, PartyId = 1, OrganisationUri = "Org1Uri", RightToBuy = true });

      dataContext.Party.Add(new Party { Id = 2, PartyTypeId = 1 });
      dataContext.Organisation.Add(new Organisation { Id = 2, PartyId = 2, OrganisationUri = "Org2Uri", RightToBuy = true });

      #region User1 contacts
      // User 1 has two contacts
      dataContext.Party.Add(new Party { Id = 3, PartyTypeId = 3 });
      dataContext.Person.Add(new Person { Id = 1, PartyId = 3, OrganisationId = 1, FirstName = "UserFN1", LastName = "UserLN1" });
      dataContext.User.Add(new User { Id = 1, IdentityProviderId = 1, PartyId = 3, UserName = "user1@mail.com" });
      dataContext.ContactPoint.Add(new ContactPoint { Id = 1, PartyId = 3, PartyTypeId = 3, ContactPointReasonId = 1, ContactDetailId = 1 });
      dataContext.ContactPoint.Add(new ContactPoint { Id = 2, PartyId = 3, PartyTypeId = 3, ContactPointReasonId = 2, ContactDetailId = 2 });

      dataContext.Party.Add(new Party { Id = 4, PartyTypeId = 2 });
      dataContext.Person.Add(new Person { Id = 2, PartyId = 4, OrganisationId = 1, FirstName = "PesronFN1", LastName = "PersonLN1" });
      dataContext.ContactDetail.Add(new ContactDetail { Id = 1, EffectiveFrom = DateTime.UtcNow });
      dataContext.VirtualAddress.Add(new VirtualAddress { Id = 1, ContactDetailId = 1, VirtualAddressTypeId = 1, VirtualAddressValue = "person1@mail.com" });
      dataContext.VirtualAddress.Add(new VirtualAddress { Id = 2, ContactDetailId = 1, VirtualAddressTypeId = 2, VirtualAddressValue = "941123456p1" });
      dataContext.ContactPoint.Add(new ContactPoint { Id = 3, PartyId = 4, PartyTypeId = 2, ContactPointReasonId = 1, ContactDetailId = 1 });

      dataContext.Party.Add(new Party { Id = 5, PartyTypeId = 2 });
      dataContext.Person.Add(new Person { Id = 3, PartyId = 5, OrganisationId = 1, FirstName = "PesronFN2", LastName = "PersonLN2" });
      dataContext.ContactDetail.Add(new ContactDetail { Id = 2, EffectiveFrom = DateTime.UtcNow });
      dataContext.VirtualAddress.Add(new VirtualAddress { Id = 3, ContactDetailId = 2, VirtualAddressTypeId = 1, VirtualAddressValue = "person2@mail.com" });
      dataContext.VirtualAddress.Add(new VirtualAddress { Id = 4, ContactDetailId = 2, VirtualAddressTypeId = 2, VirtualAddressValue = "941123456p2" });
      dataContext.ContactPoint.Add(new ContactPoint { Id = 4, PartyId = 5, PartyTypeId = 2, ContactPointReasonId = 2, ContactDetailId = 2 });
      #endregion

      #region User 2 has 1 contact (1 exisiting and 1 deleted)
      // User 2 has only 1 contact with 1 deleted contact.
      dataContext.Party.Add(new Party { Id = 6, PartyTypeId = 3 });
      dataContext.Person.Add(new Person { Id = 4, PartyId = 6, OrganisationId = 1, FirstName = "UserFN2", LastName = "UserLN2" });
      dataContext.User.Add(new User { Id = 2, IdentityProviderId = 1, PartyId = 6, UserName = "user2@mail.com" });
      dataContext.ContactPoint.Add(new ContactPoint { Id = 5, PartyId = 6, PartyTypeId = 3, ContactPointReasonId = 1, ContactDetailId = 2 });
      dataContext.ContactPoint.Add(new ContactPoint { Id = 6, PartyId = 6, PartyTypeId = 3, ContactPointReasonId = 1, ContactDetailId = 3, IsDeleted = true });

      dataContext.Party.Add(new Party { Id = 7, PartyTypeId = 2 });
      dataContext.Person.Add(new Person { Id = 5, PartyId = 7, OrganisationId = 1, FirstName = "PesronFN3", LastName = "PersonLN3" });
      dataContext.ContactDetail.Add(new ContactDetail { Id = 3, EffectiveFrom = DateTime.UtcNow, IsDeleted = true });
      dataContext.VirtualAddress.Add(new VirtualAddress { Id = 5, ContactDetailId = 3, VirtualAddressTypeId = 1, VirtualAddressValue = "email2@mail.com" });
      dataContext.VirtualAddress.Add(new VirtualAddress { Id = 6, ContactDetailId = 3, VirtualAddressTypeId = 2, VirtualAddressValue = "94112345672" });
      dataContext.ContactPoint.Add(new ContactPoint { Id = 7, PartyId = 7, PartyTypeId = 2, ContactPointReasonId = 1, ContactDetailId = 3, IsDeleted = true });
      #endregion

      #region User 3 has no contacts
      // User 3 has no contcats
      dataContext.Party.Add(new Party { Id = 8, PartyTypeId = 3 });
      dataContext.Person.Add(new Person { Id = 6, PartyId = 8, OrganisationId = 1, FirstName = "UserFN3", LastName = "UserLN3" });
      dataContext.User.Add(new User { Id = 3, IdentityProviderId = 1, PartyId = 8, UserName = "user3@mail.com" });
      #endregion

      await dataContext.SaveChangesAsync();
    }
  }
}
