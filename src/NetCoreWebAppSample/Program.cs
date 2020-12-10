namespace NetCoreWebAppSample
{
    using Common.Logging;
    using Common.Logging.Configuration;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var configuration = (IConfiguration)host.Services.GetService(typeof(IConfiguration));
            var logConfigSection = configuration.GetSection("common:logging");
            var logConfiguration = logConfigSection.Get<LogConfiguration>();
            LogManager.Configure(logConfiguration);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();

                    logging.AddConsole();
                    logging.AddCommonLogging();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
