using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using CcsSso.Security.Domain.Contracts;
using CcsSso.Security.Domain.Dtos;
using CcsSso.Security.Domain.Exceptions;
using CcsSso.Security.Services.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CcsSso.Security.Services
{
  public class Auth0IdentityProviderService : IIdentityProviderService
  {
    IAuthenticationApiClient _authenticationApiClient;
    private readonly ApplicationConfigurationInfo _appConfigInfo;
    private readonly TokenHelper _tokenHelper;
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly ICcsSsoEmailService _ccsSsoEmailService;
    public Auth0IdentityProviderService(ApplicationConfigurationInfo appConfigInfo, TokenHelper tokenHelper,
      IHttpClientFactory httpClientFactory, ICcsSsoEmailService ccsSsoEmailService)
    {
      _appConfigInfo = appConfigInfo;
      _authenticationApiClient = new AuthenticationApiClient(_appConfigInfo.Auth0ConfigurationInfo.Domain);
      _tokenHelper = tokenHelper;
      _httpClientFactory = httpClientFactory;
      _ccsSsoEmailService = ccsSsoEmailService;
    }

    /// <summary>
    /// Authenticates and issues tokens. Following Auth0 configurations are required
    /// Enable "Allow Offline Access"
    /// Enable Password grant type (Applications->Settings-> Advanced Settings->Grant Types (Password, RefreshToken)
    /// Set default connection name (Auth0 database connection name) (Profile->Settings->API Authorization Settings->Default Directory)
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userPassword"></param>
    /// <returns></returns>
    public async Task<AuthResultDto> AuthenticateAsync(string userName, string userPassword)
    {
      try
      {
        ResourceOwnerTokenRequest resourceOwnerTokenRequest = new ResourceOwnerTokenRequest()
        {
          Username = userName,
          Password = userPassword,
          ClientId = _appConfigInfo.Auth0ConfigurationInfo.ClientId,
          ClientSecret = _appConfigInfo.Auth0ConfigurationInfo.ClientSecret,
          Scope = "offline_access" //Need this to receive a refresh token
        };

        var result = await _authenticationApiClient.GetTokenAsync(resourceOwnerTokenRequest);
        var idToken = result.IdToken;
        var accessToken = result.AccessToken;
        var refreshToken = result.RefreshToken;

        return new AuthResultDto
        {
          IdToken = idToken,
          AccessToken = accessToken,
          RefreshToken = refreshToken
        };
      }
      catch (ErrorApiException e)
      {
        //if (e.Message.ToUpper() == "UNAUTHORIZED")
        //{
        //  throw new CcsSsoException("PASSWORD_RESET_REQUIRED");
        //}
        if (e.ApiError.Error == "invalid_grant") // This is the same error which we get for password reset required and invalid username/password
        {
          throw new CcsSsoException("INVALID_USERNAME_PASSWORD");
        }
        return null;
      }
    }

    public async Task<UserRegisterResult> CreateUserAsync(Domain.Dtos.UserInfo userInfo)
    {

      try
      {
        UserCreateRequest userCreateRequest = new UserCreateRequest
        {
          Email = userInfo.Email,
          Password = UtilitiesHelper.GenerateRandomPassword(),
          FullName = userInfo.FirstName,
          LastName = userInfo.LastName,
          EmailVerified = false,
          Connection = _appConfigInfo.Auth0ConfigurationInfo.DBConnectionName
        };

        var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
        using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
        {
          var result = await _managementApiClient.Users.CreateAsync(userCreateRequest);

          var ticket = await GetResetPasswordTicketAsync(userInfo.Email, managementApiToken);

          if (!string.IsNullOrEmpty(ticket))
          {
            await _ccsSsoEmailService.SendUserActivationLinkAsync(userInfo.Email, ticket);
          }

          return new UserRegisterResult()
          {
            UserName = result.Email,
            Id = result.UserId
          };
        }
      }
      catch (ErrorApiException e)
      {
        if (e.ApiError.Error == "Conflict")
        {
          throw new CcsSsoException("USERNAME_EXISTS");
        }
        else
        {
          throw new CcsSsoException("USER_REGISTRATION_FAILED");
        }
      }
    }

    public async Task UpdateUserAsync(Domain.Dtos.UserInfo userInfo)
    {
      try
      {
        UserUpdateRequest userUpdateRequest = new UserUpdateRequest
        {
          Email = userInfo.Email,
          FullName = userInfo.FirstName,
          LastName = userInfo.LastName,
          Connection = _appConfigInfo.Auth0ConfigurationInfo.DBConnectionName
        };

        var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
        using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
        {
          var result = await _managementApiClient.Users.UpdateAsync(userInfo.Id, userUpdateRequest);
        }
      }
      catch (ErrorApiException e)
      {
        if (e.ApiError.ErrorCode == "invalid_uri")
        {
          throw new RecordNotFoundException();
        }
        else
        {
          throw new CcsSsoException("USER_UPDATE_FAILED");
        }
      }
    }

    public async Task<TokenResponseInfo> GetRenewedTokensAsync(string refreshToken)
    {
      try
      {
        RefreshTokenRequest resourceOwnerTokenRequest = new RefreshTokenRequest()
        {
          ClientId = _appConfigInfo.Auth0ConfigurationInfo.ClientId,
          ClientSecret = _appConfigInfo.Auth0ConfigurationInfo.ClientSecret,
          RefreshToken = refreshToken,
          Scope = "offline_access openid profile" //Need this to receive a refresh token
        };

        var result = await _authenticationApiClient.GetTokenAsync(resourceOwnerTokenRequest);

        return new TokenResponseInfo
        {
          IdToken = result.IdToken,
          RefreshToken = result.RefreshToken,
          AccessToken = result.AccessToken
        };
      }
      catch (ErrorApiException)
      {
        throw new CcsSsoException("INVALID_REFRESH_TOKEN");
      }
    }

    public async Task<TokenResponseInfo> GetTokensAsync(TokenRequestInfo tokenRequestInfo)
    {
      //var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
      //using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
      //{
      //  try
      //  {
      //    var client = await _managementApiClient.Clients.GetAsync(_appConfigInfo.Auth0ConfigurationInfo.ClientId);
      //    if (client != null)
      //    {
      //      if (!client.Callbacks.Contains(tokenRequestInfo.RidirectUrl))
      //      {
      //        throw new CcsSsoException("INVALID_REDIRECT_URL");
      //      }

      //      AuthorizationCodeTokenRequest resourceOwnerTokenRequest = new AuthorizationCodeTokenRequest()
      //      {
      //        ClientId = _appConfigInfo.Auth0ConfigurationInfo.ClientId,
      //        // ClientSecret = _appConfigInfo.Auth0ConfigurationInfo.ClientSecret,
      //        RedirectUri = tokenRequestInfo.RidirectUrl,
      //        Code = tokenRequestInfo.Code
      //      };

      //      var result = await _authenticationApiClient.GetTokenAsync(resourceOwnerTokenRequest);

      //      return new TokenResponseInfo
      //      {
      //        IdToken = result.IdToken,
      //        RefreshToken = result.RefreshToken,
      //        AccessToken = result.AccessToken
      //      };
      //    }
      //    else
      //    {
      //      throw new CcsSsoException("INVALID_CONFIGURATION");
      //    }
      //  }
      //  catch (ErrorApiException e)
      //  {
      //    throw new UnauthorizedAccessException();
      //  }

      AuthorizationCodeTokenRequest resourceOwnerTokenRequest = new AuthorizationCodeTokenRequest()
      {
        ClientId = tokenRequestInfo.ClientId,
        // ClientSecret = _appConfigInfo.Auth0ConfigurationInfo.ClientSecret,
        RedirectUri = tokenRequestInfo.RedirectUrl,
        Code = tokenRequestInfo.Code
      };

      var result = await _authenticationApiClient.GetTokenAsync(resourceOwnerTokenRequest);

      return new TokenResponseInfo
      {
        IdToken = result.IdToken,
        RefreshToken = result.RefreshToken,
        AccessToken = result.AccessToken
      };

    }


    public async Task<List<IdentityProviderInfoDto>> ListIdentityProvidersAsync()
    {
      List<IdentityProviderInfoDto> identityProviderInfoDtos = new List<IdentityProviderInfoDto>();

      var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
      using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
      {
        try
        {
          GetConnectionsRequest getConnectionsRequest = new GetConnectionsRequest();
          PaginationInfo paginationInfo = new PaginationInfo();

          var connections = await _managementApiClient.Connections.GetAllAsync(getConnectionsRequest, paginationInfo);

          foreach (var connection in connections)
          {
            identityProviderInfoDtos.Add(new IdentityProviderInfoDto
            {
              Name = connection.Name,
            });
          }
        }
        catch (ErrorApiException)
        {
          throw new UnauthorizedAccessException();
        }
      }
      return identityProviderInfoDtos;
    }

    /// <summary>
    /// Change the password of the user by updating the user.
    /// Both UserId and NewPassword Required to chnage password.
    /// </summary>
    /// <param name="changePasswordDto"></param>
    /// <returns></returns>
    public async Task ChangePasswordAsync(ChangePasswordDto changePasswordDto)
    {
      UserUpdateRequest userUpdateRequest = new UserUpdateRequest
      {
        ClientId = _appConfigInfo.Auth0ConfigurationInfo.ClientId,
        Connection = _appConfigInfo.Auth0ConfigurationInfo.DBConnectionName,
        Password = changePasswordDto.NewPassword,
      };

      var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
      using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
      {
        try
        {
          await _managementApiClient.Users.UpdateAsync(changePasswordDto.UserId, userUpdateRequest);
        }
        catch (ErrorApiException)
        {
          throw new UnauthorizedAccessException();
        }
      }
    }

    Task<AuthResultDto> IIdentityProviderService.RespondToNewPasswordRequiredAsync(PasswordChallengeDto passwordChallengeDto)
    {
      throw new NotImplementedException();
    }

    public async Task InitiateResetPasswordAsync(string userName)
    {
      var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
      using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
      {
        var ticket = await GetResetPasswordTicketAsync(userName, managementApiToken);

        if (!string.IsNullOrEmpty(ticket))
        {
          await _ccsSsoEmailService.SendResetPasswordAsync(userName, ticket);
        }
        else
        {
          throw new CcsSsoException("INVALID_USER_NAME");
        }
      }
    }

    Task IIdentityProviderService.ResetPasswordAsync(ResetPasswordDto resetPassword)
    {
      throw new NotImplementedException();
    }

    public async Task<string> SignOutAsync(string clientId, string returnTo)
    {
      // Should include "federated" as query string para if requires to signout from federated auth providers such as Google,FB
      //var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
      //using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
      //{
      //  try
      //  {
      //    var client = await _managementApiClient.Clients.GetAsync(_appConfigInfo.Auth0ConfigurationInfo.ClientId);
      //    if (client != null)
      //    {
      //      if (!client.AllowedLogoutUrls.Contains(returnTo))
      //      {
      //        throw new CcsSsoException("INVALID_LOGOUT_URL");
      //      }

      //      var url = $"{_appConfigInfo.Auth0ConfigurationInfo.ManagementApiBaseUrl}/v2/logout?client_id={_appConfigInfo.Auth0ConfigurationInfo.ClientId}" +
      //                  $"&returnTo={returnTo}";

      //      return url;
      //    }
      //    throw new RecordNotFoundException();
      //  }
      //  catch (ErrorApiException)
      //  {
      //    throw new UnauthorizedAccessException();
      //  }
      //}
      var url = $"{_appConfigInfo.Auth0ConfigurationInfo.ManagementApiBaseUrl}/v2/logout?client_id={clientId}" +
                   $"&returnTo={returnTo}";

      return url;
    }

    public async Task RevokeTokenAsync(string refreshToken)
    {
      var client = _httpClientFactory.CreateClient();
      client.BaseAddress = new Uri(_appConfigInfo.Auth0ConfigurationInfo.ManagementApiBaseUrl);
      var url = "oauth/revoke";

      var list = new List<KeyValuePair<string, string>>();
      list.Add(new KeyValuePair<string, string>("token", refreshToken));
      list.Add(new KeyValuePair<string, string>("client_id", _appConfigInfo.Auth0ConfigurationInfo.ClientId));
      list.Add(new KeyValuePair<string, string>("client_secret", _appConfigInfo.Auth0ConfigurationInfo.ClientSecret));

      HttpContent codeContent = new FormUrlEncodedContent(list);
      await client.PostAsync(url, codeContent);
    }

    public async Task<string> GetAuthenticationEndPointAsync(string scope, string response_type, string client_id, string redirect_uri, string prompt)
    {
      string uri = $"{_appConfigInfo.Auth0ConfigurationInfo.ManagementApiBaseUrl}/authorize?client_id={client_id}" +
                  $"&response_type={response_type}&scope={scope}&redirect_uri={redirect_uri}";
      if (!string.IsNullOrEmpty(prompt))
      {
        uri = uri + "&prompt=none";
      }
      return uri;
    }

    Task<UserClaims> IIdentityProviderService.GetUserAsync(string accessToken)
    {
      throw new NotImplementedException();
    }

    public async Task DeleteAsync(string email)
    {
      var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
      using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
      {
        try
        {
          var user = (await _managementApiClient.Users.GetUsersByEmailAsync(email)).FirstOrDefault();
          if (user != null)
          {
            await _managementApiClient.Users.DeleteAsync(user.UserId);
          }
          else
          {
            throw new RecordNotFoundException();
          }
        }
        catch (ErrorApiException e)
        {
          if (e.ApiError.ErrorCode == "invalid_query_string")
          {
            throw new CcsSsoException("INVALID_EMAIL");
          }
        }
      }
    }

    public async Task<string> GetIdentityProviderAuthenticationEndPointAsync()
    {
      List<string> scopes = new List<string>() { "openid", "offline_access" };

      var managementApiToken = await _tokenHelper.GetAuth0ManagementApiTokenAsync();
      using (ManagementApiClient _managementApiClient = new ManagementApiClient(managementApiToken, _appConfigInfo.Auth0ConfigurationInfo.Domain))
      {
        try
        {
          var client = await _managementApiClient.Clients.GetAsync(_appConfigInfo.Auth0ConfigurationInfo.ClientId);
          if (client != null)
          {
            var url = $"{_appConfigInfo.Auth0ConfigurationInfo.ManagementApiBaseUrl}/authorize?client_id={_appConfigInfo.Auth0ConfigurationInfo.ClientId}&response_type=code" +
                      $"&scope={string.Join("+", scopes)}&redirect_uri={client.Callbacks.First()}";
            return url;
          }
        }
        catch (ErrorApiException)
        {
          throw new UnauthorizedAccessException();
        }
      }
      return null;
    }

    private async Task<string> GetResetPasswordTicketAsync(string userName, string managementApiToken)
    {
      var client = _httpClientFactory.CreateClient();
      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", managementApiToken);
      client.BaseAddress = new Uri(_appConfigInfo.Auth0ConfigurationInfo.ManagementApiBaseUrl);

      var url = "/api/v2/tickets/password-change";

      var userActivationLinkTTLInSeconds = _appConfigInfo.EmailConfigurationInfo.UserActivationLinkTTLInMinutes * 60;

      var list = new List<KeyValuePair<string, string>>();
      list.Add(new KeyValuePair<string, string>("email", userName));
      list.Add(new KeyValuePair<string, string>("ttl_sec", userActivationLinkTTLInSeconds.ToString()));
      list.Add(new KeyValuePair<string, string>("mark_email_as_verified", "true"));
      list.Add(new KeyValuePair<string, string>("connection_id", _appConfigInfo.Auth0ConfigurationInfo.DefaultDBConnectionId));
      list.Add(new KeyValuePair<string, string>("client_id", _appConfigInfo.Auth0ConfigurationInfo.ClientId));

      HttpContent codeContent = new FormUrlEncodedContent(list);
      var response = await client.PostAsync(url, codeContent);
      if (response.StatusCode == System.Net.HttpStatusCode.Created)
      {
        var ticket = await response.Content.ReadAsStringAsync();
        var ticketInfo = JObject.Parse(ticket).ToObject<Dictionary<string, string>>();
        return ticketInfo.FirstOrDefault().Value;
      }
      return null;
    }
  }
}
