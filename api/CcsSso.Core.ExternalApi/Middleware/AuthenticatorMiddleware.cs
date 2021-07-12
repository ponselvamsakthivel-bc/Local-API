using CcsSso.Domain.Dtos;
using CcsSso.Shared.Cache.Contracts;
using CcsSso.Shared.Contracts;
using CcsSso.Shared.Domain.Constants;
using CcsSso.Shared.Domain.Contexts;
using CcsSso.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CcsSso.ExternalApi.Middleware
{
  public class AuthenticatorMiddleware
  {

    private RequestDelegate _next;
    private readonly ApplicationConfigurationInfo _appConfig;
    private readonly ITokenService _tokenService;
    private readonly IRemoteCacheService _remoteCacheService;

    public AuthenticatorMiddleware(RequestDelegate next, ApplicationConfigurationInfo appConfig, ITokenService tokenService, IRemoteCacheService remoteCacheService)
    {
      _next = next;
      _appConfig = appConfig;
      _tokenService = tokenService;
      _remoteCacheService = remoteCacheService;
    }

    public async Task Invoke(HttpContext context, RequestContext requestContext)
    {
      var apiKey = context.Request.Headers["X-API-Key"];
      var bearerToken = context.Request.Headers["Authorization"].FirstOrDefault();
      requestContext.IpAddress = context.GetRemoteIPAddress();
      requestContext.Device = context.Request.Headers["User-Agent"];

      if (string.IsNullOrWhiteSpace(bearerToken) && (string.IsNullOrEmpty(apiKey) || apiKey != _appConfig.ApiKey))
      {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
      }
      else
      {
        if (!string.IsNullOrWhiteSpace(bearerToken))
        {
          var token = bearerToken.Split(' ').Last();
          var result = await _tokenService.ValidateTokenAsync(token, _appConfig.JwtTokenValidationInfo.JwksUrl,
            _appConfig.JwtTokenValidationInfo.IdamClienId, _appConfig.JwtTokenValidationInfo.Issuer, new List<string>() { "uid", "ciiOrgId", "sub" });

          if (result.IsValid)
          {
            var sub = result.ClaimValues["sub"];
            var pendingChangePassword = await _remoteCacheService.GetValueAsync<bool>(CacheKeyConstant.ForceSignoutKey + sub);
            if (pendingChangePassword) //check if user is entitled to force signout
            {
              throw new UnauthorizedAccessException();
            }

            var userId = result.ClaimValues["uid"];
            var ciiOrgId = result.ClaimValues["ciiOrgId"];
            requestContext.UserId = int.Parse(userId);
            requestContext.CiiOrganisationId = ciiOrgId;
          }
          else
          {
            throw new UnauthorizedAccessException();
          }
        }
        await _next(context);
      }
    }
  }
}
