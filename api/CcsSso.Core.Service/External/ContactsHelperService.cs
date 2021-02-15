using CcsSso.DbModel.Entity;
using CcsSso.Domain.Constants;
using CcsSso.Domain.Contracts;
using CcsSso.Domain.Contracts.External;
using CcsSso.Domain.Dtos.External;
using CcsSso.Domain.Exceptions;
using CcsSso.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CcsSso.Service.External
{
  public class ContactsHelperService : IContactsHelperService
  {
    private readonly IDataContext _dataContext;
    public ContactsHelperService(IDataContext dataContext)
    {
      _dataContext = dataContext;
    }

    /// <summary>
    /// Get first name and last name for a contact person from contact name, value list
    /// </summary>
    /// <param name="contacts"></param>
    /// <returns></returns>
    public (string firstName, string lastName) GetContactPersonNameTuple(List<Contact> contacts)
    {
      var firstName = string.Empty;
      var lastName = string.Empty;
      var name = contacts?.FirstOrDefault(c => c.ContactName == VirtualContactTypeName.Name)?.ContactValue;
      if (!string.IsNullOrEmpty(name))
      {
        var nameArray = name.Trim().Split(" ");
        firstName = nameArray[0];
        lastName = nameArray.Length >= 2 ? nameArray[nameArray.Length - 1] : string.Empty;
      }
      return (firstName, lastName);
    }

    /// <summary>
    /// Get the contact point reason id for the reason provided.
    /// If not return the id for OTHER reason option.
    /// </summary>
    /// <param name="reason"></param>
    /// <returns></returns>
    public async Task<int> GetContactPointReasonIdAsync(string reason)
    {
      var contactPointReason = await _dataContext.ContactPointReason.FirstOrDefaultAsync(r => r.Name == reason);

      if (contactPointReason != null)
      {
        return contactPointReason.Id;
      }
      else
      {
        throw new CcsSsoException(ErrorConstant.ErrorInvalidContactReason);
      }
    }

    /// <summary>
    /// Validate the contact details
    /// </summary>
    /// <param name="contacts"></param>
    public void ValidateContacts(List<Contact> contacts)
    {
      var validContactsNameList = new List<string> { VirtualContactTypeName.Email, VirtualContactTypeName.Phone,
        VirtualContactTypeName.Fax, VirtualContactTypeName.Url, VirtualContactTypeName.Name };

      if (contacts == null || !contacts.Any())
      {
        throw new CcsSsoException(ErrorConstant.ErrorInvalidContacts);
      }

      if (contacts.Any(c => !validContactsNameList.Contains(c.ContactName)))
      {
        throw new CcsSsoException(ErrorConstant.ErrorInvalidContactName);
      }

      var email = contacts.FirstOrDefault(c => c.ContactName == VirtualContactTypeName.Email)?.ContactValue;

      if (!string.IsNullOrEmpty(email) && !UtilitiesHelper.IsEmailValid(email))
      {
        throw new CcsSsoException(ErrorConstant.ErrorInvalidEmail);
      }
    }

    /// <summary>
    /// Get the in memory contact point object to use in both create and update methods
    /// </summary>
    /// <param name="contacts"></param>
    /// <param name="contactPoint"></param>
    /// <returns></returns>
    public async Task AssignVirtualContactsToContactPointAsync(List<Contact> contacts, ContactPoint contactPoint)
    {
      List<VirtualAddress> virtualAddresses = await GetVirtualAddressesAsync(contacts);

      if (virtualAddresses.Any())
      {
        if (contactPoint.ContactDetail.VirtualAddresses != null)
        {
          contactPoint.ContactDetail.VirtualAddresses.RemoveAll(va => true);
          contactPoint.ContactDetail.VirtualAddresses.AddRange(virtualAddresses);
        }
        else
        {
          contactPoint.ContactDetail.VirtualAddresses = virtualAddresses;
        }
      }
    }

    /// <summary>
    /// Get the virtual addresses entities for contacts
    /// </summary>
    /// <param name="contacts"></param>
    /// <returns></returns>
    private async Task<List<VirtualAddress>> GetVirtualAddressesAsync(List<Contact> contacts)
    {
      var virtualAddressTypes = await _dataContext.VirtualAddressType.ToListAsync();

      List<VirtualAddress> virtualAddresses = new List<VirtualAddress>();

      foreach (var contact in contacts)
      {
        if (!string.IsNullOrEmpty(contact.ContactValue) && contact.ContactName != VirtualContactTypeName.Name)
        {
          var virtualAddress = new VirtualAddress
          {
            VirtualAddressTypeId = virtualAddressTypes.FirstOrDefault(t => t.Name == contact.ContactName).Id,
            VirtualAddressValue = contact.ContactValue
          };
          virtualAddresses.Add(virtualAddress);
        }
      }
      return virtualAddresses;
    }
  }
}
