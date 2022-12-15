using Serilog;

namespace Project.Extensions
{
    public static class LoggerExtension
    {
        public static IHostBuilder UseSerilogConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return hostBuilder;
        }
    }
}
