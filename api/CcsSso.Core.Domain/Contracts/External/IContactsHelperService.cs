using CcsSso.DbModel.Entity;
using CcsSso.Domain.Dtos.External;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.Domain.Contracts.External
{
  public interface IContactsHelperService
  {
    (string firstName, string lastName) GetContactPersonNameTuple(List<Contact> contacts);

    Task<int> GetContactPointReasonIdAsync(string reason);

    void ValidateContacts(List<Contact> contacts);

    Task AssignVirtualContactsToContactPointAsync(List<Contact> contacts, ContactPoint contactPoint);
  }
}
