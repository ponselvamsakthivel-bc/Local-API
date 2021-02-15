using System;
using System.Threading.Tasks;
using VaultSharp;
using VaultSharp.V1.AuthMethods.AppRole;
using VaultSharp.V1.Commons;
using VaultSharp.V1.SecretsEngines;
using Microsoft.Extensions.Configuration;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.AuthMethods;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CcsSso.Api.CustomOptions
{
  public class VaultConfigurationProvider : ConfigurationProvider
  {
    public VaultOptions _config;
    private IVaultClient _client;

    public VaultConfigurationProvider(VaultOptions config)
    {
      _config = config;
      IAuthMethodInfo authMethod = new TokenAuthMethodInfo(vaultToken: System.Environment.GetEnvironmentVariable("VAULT_TOKEN", EnvironmentVariableTarget.Machine));
      var vaultClientSettings = new VaultClientSettings(_config.Address, authMethod) {
        ContinueAsyncTasksOnCapturedContext = false
      };
      _client = new VaultClient(vaultClientSettings);
    }

    public override void Load()
    {
      LoadAsync().Wait();
    }

    public async Task LoadAsync()
    {
      await GetSecrets();
    }

    public async Task GetSecrets()
    {
      var _secrets = await _client.V1.Secrets.Cubbyhole.ReadSecretAsync(secretPath: System.Environment.GetEnvironmentVariable("VAULT_SECRET_PATH_2", EnvironmentVariableTarget.Machine));
      var _dbConnection = _secrets.Data["DbConnection"].ToString();

      Data.Add("DbConnection", _dbConnection);
    }
  }

  public class VaultConfigurationSource : IConfigurationSource
  {
    private VaultOptions _config;

    public VaultConfigurationSource(Action<VaultOptions> config)
    {
      _config = new VaultOptions();
      config.Invoke(_config);
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
      return new VaultConfigurationProvider(_config);
    }
  }

  public class VaultOptions
  {
    public string Address { get; set; }
  }

  public static class VaultExtensions
  {
    public static IConfigurationBuilder AddVault(this IConfigurationBuilder configuration,
    Action<VaultOptions> options)
    {
      var vaultOptions = new VaultConfigurationSource(options);
      configuration.Add(vaultOptions);
      return configuration;
    }
  }
}
