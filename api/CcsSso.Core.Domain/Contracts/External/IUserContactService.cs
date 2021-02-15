using CcsSso.Domain.Dtos.External;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.Domain.Contracts.External
{
  public interface IUserContactService
  {
    Task<int> CreateUserContactAsync(int userId, ContactInfo contactInfo);

    Task DeleteUserContactAsync(int userId, int contactId);

    Task<List<UserContactInfo>> GetUserContactsListAsync(int userId, string contactType = null);

    Task<UserContactInfo> GetUserContactAsync(int userId, int contactId);

    Task UpdateUserContactAsync(int userId, int contactId, ContactInfo contactInfo);
  }
}
