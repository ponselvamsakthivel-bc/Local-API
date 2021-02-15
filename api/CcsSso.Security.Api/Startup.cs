using CcsSso.Logs.Extensions;
using CcsSso.Security.Api.CustomOptions;
using CcsSso.Security.Api.Middleware;
using CcsSso.Security.Domain.Contracts;
using CcsSso.Security.Domain.Dtos;
using CcsSso.Security.Services;
using CcsSso.Security.Services.Helpers;
using CcsSso.Security.Services.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace CcsSso.Security.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<VaultOptions>(Configuration.GetSection("Vault"));
      services.AddDataProtection();
      services.AddControllers(opt =>
      {
        // remove formatter that turns nulls into 204 - No Content responses this formatter breaks Angular's Http response JSON parsing
        opt.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter>();
      });
      services.AddSingleton(s =>
      {
        ApplicationConfigurationInfo appConfigInfo = new ApplicationConfigurationInfo()
        {
          Auth0ConfigurationInfo = new Auth0Configuration()
          {
            ClientId = Configuration["Auth0:ClientId"],
            ClientSecret = Configuration["Auth0:Secret"],
            Domain = Configuration["Auth0:Domain"],
            DBConnectionName = Configuration["Auth0:DBConnectionName"],
            ManagementApiBaseUrl = Configuration["Auth0:ManagementApiBaseUrl"],
            ManagementApiIdentifier = Configuration["Auth0:ManagementApiIdentifier"],
            UserStore = Configuration["Auth0:UserStore"],
            DefaultDBConnectionId = Configuration["Auth0:DefaultDBConnectionId"]
          },
          AwsCognitoConfigurationInfo = new AwsCognitoConfigurationInfo()
          {
            AWSRegion = Configuration["AWSCognito:Region"],
            AWSPoolId = Configuration["AWSCognito:PoolId"],
            AWSAppClientId = Configuration["AWSCognito:AppClientId"],
            AWSAccessKeyId = Configuration["AWSCognito:AccessKeyId"],
            AWSAccessSecretKey = Configuration["AWSCognito:AccessSecretKey"],
            AWSCognitoURL = Configuration["AWSCognito:AWSCognitoURL"]
          },
          EmailConfigurationInfo = new EmailConfigurationInfo()
          {
            ApiKey = Configuration["Email:ApiKey"],
            UserActivationEmailTemplateId = Configuration["Email:UserActivationEmailTemplateId"],
            UserActivationLinkTTLInMinutes = int.Parse(Configuration["Email:UserActivationLinkTTLInMinutes"]),
            ResetPasswordEmailTemplateId = Configuration["Email:ResetPasswordEmailTemplateId"]
          }
        };
        return appConfigInfo;
      });

      // This could be a temporary checking to register the identity provider service.
      if (Configuration["IdentityProvider"] == "AUTH0")
      {
        services.AddSingleton<IIdentityProviderService, Auth0IdentityProviderService>();
      }
      else
      {
        services.AddSingleton<IIdentityProviderService, AwsIdentityProviderService>();        
      }
      services.AddSingleton<TokenHelper>();
      services.AddSingleton<IEmaillProviderService, CustomEmailProviderService>();
      services.AddSingleton<ICcsSsoEmailService, CcsSsoEmailService>();
      services.AddScoped<ISecurityService, SecurityService>();
      services.AddScoped<IUserManagerService, UserManagerService>();
      services.AddHttpClient("default").ConfigurePrimaryHttpMessageHandler(() =>
      {
        return new HttpClientHandler()
        {
          AllowAutoRedirect = true,
          UseDefaultCredentials = true
        };
      });
      services.AddCors();

      var jwtTokenInfo = Configuration.GetSection("JwtTokenInfo");
      JwtSettings jwtSettings = new JwtSettings();
      jwtTokenInfo.Bind(jwtSettings);

      services
          .AddAuthentication(options =>
          {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          })
          .AddJwtBearer(options =>
          {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuerSigningKey = true,
              IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
              {
                // Get JsonWebKeySet from AWS
                var json = new WebClient().DownloadString(jwtSettings.JWTKeyEndpoint);
                // Serialize the result
                return JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
              },
              ValidateIssuer = jwtSettings.ValidateIssuer,
              ValidIssuer = jwtSettings.Issuer,
              ValidateLifetime = true,
              LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
              ValidateAudience = jwtSettings.ValidateAudience,
              ValidAudience = jwtSettings.Audience,
            };
          });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "CcsSso.Security.Api", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        c.EnableAnnotations();
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.AddLoggerMiddleware();// Registers the logger configured on the core library 
      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CcsSso.Security.Api v1"));

      app.UseHttpsRedirection();
      app.UseRouting();

      List<string> corsDomains = new List<string>();
      Configuration.Bind("CorsDomains", corsDomains);

      app.UseCors(builder => builder.WithOrigins(corsDomains.ToArray())
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
      );

      app.UseMiddleware<CommonExceptionHandlerMiddleware>();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
