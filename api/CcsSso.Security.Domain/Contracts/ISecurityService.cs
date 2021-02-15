using CcsSso.Security.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.Security.Domain.Contracts
{
  public interface ISecurityService
  {
    Task<AuthResultDto> LoginAsync(string userName, string userPassword);

    Task<string> GetAuthenticationEndPointAsync(string callbackUrl);

    Task<TokenResponseInfo> GetRenewedTokenAsync(TokenRequestInfo tokenRequestInfo);

    Task<List<IdentityProviderInfoDto>> GetIdentityProvidersListAsync();

    Task ChangePasswordAsync(ChangePasswordDto changePassword);

    Task<AuthResultDto> ChangePasswordWhenPasswordChallengeAsync(PasswordChallengeDto passwordChallengeDto);

    Task InitiateResetPasswordAsync(string userName);

    Task ResetPasswordAsync(ResetPasswordDto resetPassword);

    Task<string> LogoutAsync(string userName);

    Task<string> GetIdentityProviderAuthenticationEndPointAsync();

    Task RevokeTokenAsync(string refreshToken);
  }
}
