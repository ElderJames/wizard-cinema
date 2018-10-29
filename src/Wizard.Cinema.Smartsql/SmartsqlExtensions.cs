using System;
using Infrastructures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using SmartSql;

namespace Wizard.Cinema.Smartsql
{
    public static class SmartsqlExtensions
    {
        public static void AddSmartSqlStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSmartSql(sp => new SmartSqlOptions()
            {
                Alias = "cinema",
                LoggerFactory = sp.GetService<ILoggerFactory>(),
                ConfigPath = "Cinema-SmartSqlMapConfig.xml"
            });
            services.AddSmartSqlRepositoryFactory(sqlIdNamingConvert: (type, method) =>
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
                options.GetSmartSql = sp => sp.GetSmartSqlMapper("cinema");
            });
            services.AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "Wizard.Cinema.QueryServices";
                options.ScopeTemplate = "I{Scope}QueryService";
                options.GetSmartSql = sp => sp.GetSmartSqlMapper("cinema");
            });

            services.TryAddSingleton<ITransactionRepository, SmartSqlTransactionRepository>();
        }
    }
}
