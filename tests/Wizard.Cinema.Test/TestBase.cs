using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Wizard.Cinema.Remote;

namespace Wizard.Cinema.Test
{
    public class TestBase
    {
        protected IServiceProvider ServiceProvider;

        public TestBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            var configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("log.txt", LogEventLevel.Debug)
                .WriteTo.Console(LogEventLevel.Debug)
                .CreateLogger();

            var services = new ServiceCollection();
            services.AddLogging();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

            services.AddRemote();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}