﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Kurmann.AutomateVideoPublishing.ServiceCollectionIntegratedModule.Module;

namespace Kurmann.AutomateVideoPublishing.ServiceCollectionIntegratedModule.ConsoleApp;

internal class Program
{
    static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddEnvironmentVariables(prefix: "SamplePrefix_");
            })
            .ConfigureServices((hostContext, services) =>
            {
                var moduleSettings = new ModuleSettings();
                hostContext.Configuration.Bind(moduleSettings);
                services.AddSingleton(moduleSettings);
                services.Configure<ModuleSettings>(hostContext.Configuration);

                services.AddServiceCollectionIntegratedModule(moduleSettings);

                services.AddLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.AddConsole();
                });
            });
    }
}