using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartSql;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Spider;

namespace Wizard.Cinema.Remote
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRemote(this IServiceCollection services)
        {
            services.AddHttpClient("movieInfo");
            services.AddSingleton<RemoteSpider>();
            services.AddSingleton<CityService>();
            services.AddSingleton<CinemaService>();
            services.AddSingleton<HallService>();

            services.AddRepositoryFactory(sqlIdNamingConvert: (type, method) =>
            {
                int index = method.Name.IndexOf("By", StringComparison.Ordinal);
                if (index <= 0)
                    index = method.Name.IndexOf("To", StringComparison.Ordinal);

                return index <= 0 ? method.Name : method.Name.Substring(0, index);
            });

            services.AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "Wizard.Cinema.Remote";
                options.GetSmartSql = sp => MapperContainer.Instance.GetSqlMapper(new SmartSqlOptions()
                {
                    Alias = "remote",
                    LoggerFactory = sp.GetService<ILoggerFactory>(),
                    ConfigPath = "Remote-SmartSqlMapConfig.xml"
                });
            });
        }
    }
}
