using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CcsSso.Logs
{
  public class LogConfigurationManager
  {
    public static void ConfigureLogs(string section)
    {
      var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
       .ReadFrom.Configuration(configuration, sectionName: section)
#if DEBUG
           .WriteTo.Console()
#endif
           .CreateLogger();
    }
  }
}
