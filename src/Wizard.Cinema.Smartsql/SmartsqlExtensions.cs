using System;
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

            services.AddRepositoryFactory(sqlIdNamingConvert: (type, method) =>
            {
                if (method.Name.StartsWith("Update"))
                    return "Update";

                int index = method.Name.IndexOf("By", StringComparison.Ordinal);
                if (index <= 0)
                    index = method.Name.IndexOf("To", StringComparison.Ordinal);

                return index <= 0 ? method.Name : method.Name.Substring(0, index);
            });
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
