using System;
using Janno.Data.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Janno {

  public class Program {

    public static void Main(string[] args) {
      var host = CreateHostBuilder(args).Build();

      using (var scope = host.Services.CreateScope()) {
        var services = scope.ServiceProvider;
//
        try {
//          // User
          var userContext = services.GetRequiredService<UserContext>();
          userContext.Database.EnsureCreated();
          UserContextInitializer.Initialize(userContext);
        } catch (Exception e) {
          Console.WriteLine(e);
          // ignored
        }
      }

      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => {
          webBuilder.UseStartup<Startup>();
          webBuilder.UseKestrel(options =>
            options.ListenLocalhost(5001, listenOptions => {
              listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
              listenOptions.UseHttps();
            }));
        });

  }

}