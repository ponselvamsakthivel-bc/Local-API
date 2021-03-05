using CcsSso.Security.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.Security.Domain.Contracts
{
  public interface ISecurityService
  {
    Task<AuthResultDto> LoginAsync(string userName, string userPassword);

    Task<string> GetAuthenticationEndPointAsync(string scope, string response_type, string client_id, string redirect_uri, string prompt);

    Task<TokenResponseInfo> GetRenewedTokenAsync(TokenRequestInfo tokenRequestInfo, string opbsValue, string host);

    Task<List<IdentityProviderInfoDto>> GetIdentityProvidersListAsync();

    Task ChangePasswordAsync(ChangePasswordDto changePassword);

    Task<AuthResultDto> ChangePasswordWhenPasswordChallengeAsync(PasswordChallengeDto passwordChallengeDto);

    Task InitiateResetPasswordAsync(string userName);

    Task ResetPasswordAsync(ResetPasswordDto resetPassword);

    Task<string> LogoutAsync(string clientId, string redirecturi);

    Task<string> GetIdentityProviderAuthenticationEndPointAsync();

    Task RevokeTokenAsync(string refreshToken);
  }
}
