namespace House.API
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using Serilog.Events;
    using Serilog.Formatting.Json;

    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(
                    new JsonFormatter(renderMessage: true),
                    Path.Combine(AppContext.BaseDirectory, "logs//Serilog.json"),
                    shared: true,
                    fileSizeLimitBytes: 20_971_520,
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: 10)
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
