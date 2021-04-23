using CcsSso.Core.Domain.Dtos.External;
using System.Threading.Tasks;

namespace CcsSso.Core.Domain.Contracts.External
{
  public interface IUserProfileService
  {
    Task<UserEditResponseInfo> CreateUserAsync(UserProfileEditRequestInfo userProfileRequestInfo);

    Task DeleteUserAsync(string userName);

    Task<UserProfileResponseInfo> GetUserAsync(string userName);

    Task<UserListResponse> GetUsersAsync(string organisationId, ResultSetCriteria resultSetCriteria, string searchString = null);

    Task<UserEditResponseInfo> UpdateUserAsync(string userName, UserProfileEditRequestInfo userProfileRequestInfo);

    Task<UserEditResponseInfo> UpdateUserRolesAsync(string userName, UserProfileEditRequestInfo userProfileRequestInfo);

    Task<UserEditResponseInfo> AddAdminRoleAsync(string userName, UserProfileEditRequestInfo userProfileRequestInfo);
  }
}
