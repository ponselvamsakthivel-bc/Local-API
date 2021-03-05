using CcsSso.Security.Domain.Contracts;
using CcsSso.Security.Domain.Dtos;
using CcsSso.Security.Domain.Exceptions;
using CcsSso.Security.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.Security.Services
{
  public class SecurityService : ISecurityService
  {

    private readonly IIdentityProviderService _identityProviderService;
    public SecurityService(IIdentityProviderService awsIdentityProviderService)
    {
      _identityProviderService = awsIdentityProviderService;
    }

    public async Task<AuthResultDto> LoginAsync(string userName, string userPassword)
    {
      var result = await _identityProviderService.AuthenticateAsync(userName, userPassword);
      return result;
    }

    public async Task<TokenResponseInfo> GetRenewedTokenAsync(TokenRequestInfo tokenRequestInfo, string opbsValue, string host)
    {
      if (string.IsNullOrEmpty(tokenRequestInfo.Code) && string.IsNullOrEmpty(tokenRequestInfo.GrantType))
      {
        throw new CcsSsoException("INVALID_TOKEN");
      }
      TokenResponseInfo tokenResponseInfo;
      if (tokenRequestInfo.GrantType == "authorization_code")
      {
        if (string.IsNullOrEmpty(tokenRequestInfo.Code))
        {
          throw new CcsSsoException("CODE_REQUIRED");
        }

        Random rnd = new Random();
        var salt = rnd.Next(1, 6);
        // Generate Session_state and attach to the response
        var sessionState = tokenRequestInfo.ClientId + " " + host + " " + opbsValue + " " + salt;
        var sessionHash = CryptoProvider.GenerateSaltedHash(sessionState);
        var sessionStateHashWithSalt = sessionHash + "." + salt;
        tokenResponseInfo = await _identityProviderService.GetTokensAsync(tokenRequestInfo);
        tokenResponseInfo.SessionState = sessionStateHashWithSalt;
      }
      else if (tokenRequestInfo.GrantType == "refresh_token")
      {
        if (string.IsNullOrEmpty(tokenRequestInfo.RefreshToken))
        {
          throw new CcsSsoException("REFRESH_TOKEN_REQUIRED");
        }

        tokenResponseInfo = await _identityProviderService.GetRenewedTokensAsync(tokenRequestInfo.RefreshToken);
      }
      else
      {
        throw new CcsSsoException("UNSUPPORTED_GRANT_TYPE");
      }
      return tokenResponseInfo;
    }

    public async Task<string> GetIdentityProviderAuthenticationEndPointAsync()
    {
      return await _identityProviderService.GetIdentityProviderAuthenticationEndPointAsync();
    }

    public async Task<List<IdentityProviderInfoDto>> GetIdentityProvidersListAsync()
    {
      var idProviders = await _identityProviderService.ListIdentityProvidersAsync();
      return idProviders;
    }

    public async Task ChangePasswordAsync(ChangePasswordDto changePassword)
    {
      if (string.IsNullOrEmpty(changePassword.AccessToken))
      {
        throw new CcsSsoException("ACCESS_TOKEN_REQUIRED");
      }
      if (string.IsNullOrEmpty(changePassword.NewPassword))
      {
        throw new CcsSsoException("NEW_PASSWORD_REQUIRED");
      }
      if (string.IsNullOrEmpty(changePassword.OldPassword))
      {
        throw new CcsSsoException("OLD_PASSWORD_REQUIRED");
      }
      await _identityProviderService.ChangePasswordAsync(changePassword);
    }

    public async Task<AuthResultDto> ChangePasswordWhenPasswordChallengeAsync(PasswordChallengeDto passwordChallengeDto)
    {
      if (string.IsNullOrEmpty(passwordChallengeDto.UserName))
      {
        throw new CcsSsoException("USERNAME_REQUIRED");
      }
      if (string.IsNullOrEmpty(passwordChallengeDto.NewPassword))
      {
        throw new CcsSsoException("NEW_PASSWORD_REQUIRED");
      }
      if (string.IsNullOrEmpty(passwordChallengeDto.SessionId))
      {
        throw new CcsSsoException("SESSION_ID_REQUIRED");
      }
      return await _identityProviderService.RespondToNewPasswordRequiredAsync(passwordChallengeDto);
    }

    public async Task InitiateResetPasswordAsync(string userName)
    {
      if (string.IsNullOrEmpty(userName))
      {
        throw new CcsSsoException("USERNAME_REQUIRED");
      }
      await _identityProviderService.InitiateResetPasswordAsync(userName);
    }

    public async Task ResetPasswordAsync(ResetPasswordDto resetPassword)
    {
      if (string.IsNullOrEmpty(resetPassword.VerificationCode))
      {
        throw new CcsSsoException("VERIFICATION_CODE_REQUIRED");
      }
      if (string.IsNullOrEmpty(resetPassword.UserName))
      {
        throw new CcsSsoException("USERNAME_REQUIRED");
      }
      if (string.IsNullOrEmpty(resetPassword.NewPassword))
      {
        throw new CcsSsoException("NEW_PASSWORD_REQUIRED");
      }
      await _identityProviderService.ResetPasswordAsync(resetPassword);
    }

    public async Task<string> LogoutAsync(string clientId, string redirecturi)
    {
      if (string.IsNullOrEmpty(redirecturi))
      {
        throw new CcsSsoException("REDIRECT_URI_REQUIRED");
      }
      return await _identityProviderService.SignOutAsync(clientId, redirecturi);
    }

    public async Task<string> GetAuthenticationEndPointAsync(string scope, string response_type, string client_id, string redirect_uri, string prompt)
    {
      if (string.IsNullOrEmpty(client_id))
      {
        throw new CcsSsoException("CLIENT_ID_REQUIRED");
      }
      if (string.IsNullOrEmpty(response_type))
      {
        throw new CcsSsoException("RESPONSE_TYPE_REQUIRED");
      }
      if (string.IsNullOrEmpty(redirect_uri))
      {
        throw new CcsSsoException("REDIRECT_URI_REQUIRED");
      }
      if (string.IsNullOrEmpty(scope))
      {
        throw new CcsSsoException("SCOPE_REQUIRED");
      }
      return await _identityProviderService.GetAuthenticationEndPointAsync(scope, response_type, client_id, redirect_uri, prompt);
    }

    public async Task RevokeTokenAsync(string refreshToken)
    {
      if (string.IsNullOrEmpty(refreshToken))
      {
        throw new CcsSsoException("REFRESH_TOKEN_REQUIRED");
      }
      await _identityProviderService.RevokeTokenAsync(refreshToken);
    }
  }
}
