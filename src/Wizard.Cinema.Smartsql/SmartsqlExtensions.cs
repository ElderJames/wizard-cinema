using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartSql.Options;

namespace Wizard.Cinema.Smartsql
{
    public static class SmartsqlExtensions
    {
        public static void AddSmartSqlStorage(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSmartSql();
            services.AddSmartSql(configuration.GetSection("SmartSql"));

            services.AddRepositoryFactory();
            services.AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "Wizard.Cinema.Domain";
            });
            services.AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "Wizard.Cinema.QueryServices";
                options.ScopeTemplate = "I{Scope}QueryService";
            });
        }

        public static IServiceCollection AddSmartSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddSmartSql();
            services.AddSmartSqlOption();
            services.Configure<SmartSqlConfigOptions>(configuration);
            return services;
        }
    }
}