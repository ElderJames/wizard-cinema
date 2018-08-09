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

            services.AddSmartSql();
            services.AddRepositoryFactory();
            services.AddRepositoryFromAssembly(options =>
            {
                options.GetSmartSql = sp => new SmartSqlMapper(sp.GetRequiredService<ILoggerFactory>(), "SmartSqlConfig.xml");
                options.AssemblyString = "Wizard.Cinema.Remote";
            });
        }
    }
}