using CcsSso.Security.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.Security.Domain.Contracts
{
  public interface IIdentityProviderService
  {
    Task<AuthResultDto> AuthenticateAsync(string userName, string userPassword);

    Task<UserRegisterResult> CreateUserAsync(UserInfo userInfo);

    Task UpdateUserAsync(UserInfo userInfo);

    Task<TokenResponseInfo> GetRenewedTokensAsync(string refreshToken);

    Task<TokenResponseInfo> GetTokensAsync(TokenRequestInfo tokenRequestInfo);

    Task RevokeTokenAsync(string refreshToken);

    Task<List<IdentityProviderInfoDto>> ListIdentityProvidersAsync();

    Task ChangePasswordAsync(ChangePasswordDto changePassword);

    Task<AuthResultDto> RespondToNewPasswordRequiredAsync(PasswordChallengeDto passwordChallengeDto);

    Task InitiateResetPasswordAsync(string userName);

    Task ResetPasswordAsync(ResetPasswordDto resetPassword);

    Task<string> SignOutAsync(string clientId, string userName);

    Task<UserClaims> GetUserAsync(string accessToken);

    Task DeleteAsync(string email);

    Task<string> GetIdentityProviderAuthenticationEndPointAsync();

    Task<string> GetAuthenticationEndPointAsync(string scope, string response_type, string client_id, string redirect_uri, string prompt);
  }
}
