using CcsSso.Logs;
using CcsSso.Logs.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using CcsSso.Security.Api.CustomOptions;

namespace CcsSso.Security.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {      
      CreateHostBuilder(args).Build().Run();
      
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
              config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
              var builtConfig = config.Build();
              config.AddVault(options =>
              {
                var vaultOptions = builtConfig.GetSection("Vault");
                options.Address = vaultOptions["Address"];
              });
            })
            .UseApplicationLog() //Registers the Logger. This could depend on the actual configurations unique to each logger
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });

  }
}