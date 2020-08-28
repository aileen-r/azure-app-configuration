using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TestAppConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var settings = config.Build();
#if DEBUG                
                config.AddAzureAppConfiguration(options =>
                {
                    options.Connect(settings["ConnectionStrings:AppConfig"])
                        .ConfigureKeyVault(kv =>
                        {
                            kv.SetCredential(new DefaultAzureCredential());
                        });
                });
            })
#else

                var credentials = new ManagedIdentityCredential();
                config.AddAzureAppConfiguration(options =>
                {
                    options.Connect(new Uri(settings["AppConfig:Endpoint"]), credentials)
                        .ConfigureKeyVault(kv =>
                        {
                            kv.SetCredential(credentials);
                        });
                });
#endif
            .UseStartup<Startup>());
    }
}
