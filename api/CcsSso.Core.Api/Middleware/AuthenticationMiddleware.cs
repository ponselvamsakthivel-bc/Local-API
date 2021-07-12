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
using System.Threading.Tasks;

namespace CcsSso.Core.Api.Middleware
{
  public class AuthenticationMiddleware
  {
    private RequestDelegate _next;
    private readonly ITokenService _tokenService;
    private readonly ApplicationConfigurationInfo _applicationConfigurationInfo;
    private readonly IRemoteCacheService _remoteCacheService;
    private List<string> allowedPaths = new List<string>()
    {
      "auth/backchannel_logout", "auth/sign_out", "auth/get_refresh_token",
      "organisation/rollback", "organisation", "user", "user/useractivationemail", "user/getuser", "contact"
    };
    private const string allowedCiiRoute = "cii";
    private List<string> restrictedCiiPaths = new List<string>()
    {
      "cii/DeleteScheme"
    };

    public AuthenticationMiddleware(RequestDelegate next, ITokenService tokenService,
      ApplicationConfigurationInfo applicationConfigurationInfo, IRemoteCacheService remoteCacheService)
    {
      _next = next;
      _tokenService = tokenService;
      _applicationConfigurationInfo = applicationConfigurationInfo;
      _remoteCacheService = remoteCacheService;
    }

    public async Task Invoke(HttpContext context, RequestContext requestContext)
    {
      var path = context.Request.Path.Value.TrimStart('/').TrimEnd('/');
      requestContext.IpAddress = context.GetRemoteIPAddress();
      requestContext.Device = context.Request.Headers["User-Agent"];

      if (allowedPaths.Contains(path) || (path.Contains(allowedCiiRoute) && !restrictedCiiPaths.Any(rp => rp == path)))
      {
        await _next(context);
        return;
      }

      if (context.Request.Headers.ContainsKey("Authorization"))
      {
        var bearerToken = context.Request.Headers["Authorization"].FirstOrDefault();
        if (!string.IsNullOrEmpty(bearerToken))
        {
          var token = bearerToken.Split(' ').Last();
          var result = await _tokenService.ValidateTokenAsync(token, _applicationConfigurationInfo.JwtTokenValidationInfo.JwksUrl,
            _applicationConfigurationInfo.JwtTokenValidationInfo.IdamClienId, _applicationConfigurationInfo.JwtTokenValidationInfo.Issuer, new List<string>() { "uid", "ciiOrgId", "sub" });

          if (result.IsValid)
          {
            var userId = result.ClaimValues["uid"];
            var ciiOrgId = result.ClaimValues["ciiOrgId"];
            var sub = result.ClaimValues["sub"];

            var pendingChangePassword = await _remoteCacheService.GetValueAsync<bool>(CacheKeyConstant.ForceSignoutKey + sub);
            if (path == "auth/create_session" && pendingChangePassword)
            {
              await _remoteCacheService.RemoveAsync(CacheKeyConstant.ForceSignoutKey + sub);
            }
            else if (pendingChangePassword) //check if user is entitled to force signout
            {
              throw new UnauthorizedAccessException();
            }

            requestContext.UserId = int.Parse(userId);
            requestContext.CiiOrganisationId = ciiOrgId;
            await _next(context);
          }
          else
          {
            throw new UnauthorizedAccessException();
          }
        }
      }
      else
      {
        throw new UnauthorizedAccessException();
      }
    }
  }
}
