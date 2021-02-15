using CcsSso.Domain.Constants;
using CcsSso.Domain.Dtos.External;
using CcsSso.Dtos.Domain.Models;
using System.Collections.Generic;

namespace CcsSso.Tests.Infrastructure
{
  internal static class DtoHelper
  {
    public static ContactDetailDto GetContactDetailDto(int contactId, int partyId, int organisationId, ContactType contactType,
      string name, string email, string phone, Address address = null)
    {
      return new ContactDetailDto
      {
        ContactId = contactId,
        PartyId = partyId,
        OrganisationId = organisationId,
        ContactType = contactType,
        Name = name,
        Email = email,
        PhoneNumber = phone,
        Address = address
      };
    }

    public static ContactInfo GetContactInfo(string contactReason, List<Contact> contacts)
    {
      return new ContactInfo
      {
        ContactReason = contactReason,
        Contacts = contacts
      };
    }

    public static Contact GetContact(string contacName, string value)
    {
      return new Contact
      {
        ContactName = contacName,
        ContactValue = value
      };
    }
  }
}
