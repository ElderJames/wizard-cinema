using System;
using System.Collections.Generic;
using Infrastructures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using SmartSql;
using SmartSql.Configuration;
using SmartSql.Options;
using SmartSql.TypeHandler;
using Database = SmartSql.Options.Database;

namespace Wizard.Cinema.Smartsql
{
    public static class SmartsqlExtensions
    {
        public static void AddSmartSqlStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration["connectionString"]);
            services.AddQuery(configuration["connectionString"]);
            services.AddSingleton<ITransactionRepository, SmartSqlTransaction>();
        }

        public static void AddRepository(this IServiceCollection services, string conStr)
        {
            var cmdConfig = new SmartSqlConfigOptions()
            {
                Database = new Database()
                {
                    DbProvider = new DbProvider()
                    {
                        Name = nameof(MySqlClientFactory),
                        ParameterPrefix = "@",
                        Type = typeof(MySqlClientFactory).AssemblyQualifiedName,
                    },
                    Write = new WriteDataSource()
                    {
                        Name = "Write-DB",
                        ConnectionString = conStr
                    }
                },
                Settings = new Settings()
                {
                    ParameterPrefix = "@",
                    IgnoreParameterCase = true,
                    IsWatchConfigFile = true
                },
                SmartSqlMaps = new List<SmartSqlMapSource>()
                {
                    new SmartSqlMapSource() { Path = "SqlMaps", Type = SmartSqlMapSource.ResourceType.Directory }
                },
                TypeHandlers = new List<TypeHandler>()
                {
                    new TypeHandler() { Handler = new JsonTypeHandler(), Name = "Json", Type = typeof(JsonTypeHandler).AssemblyQualifiedName }
                }
            };

            services.AddSmartSql(sp => new SmartSqlOptions()
            {
                Alias = "cinema_cmd",
                LoggerFactory = sp.GetService<ILoggerFactory>(),
                ConfigLoader = new OptionConfigLoader(cmdConfig, sp.GetService<ILoggerFactory>())
            });

            services.AddRepositoryFactory(sqlIdNamingConvert: (type, method) => method.Name.StartsWith("Update") ? "Update" : method.Name);
            services.AddRepositoryFromAssembly(option =>
            {
                option.AssemblyString = "Wizard.Cinema.Domain";
                option.ScopeTemplate = "I{Scope}Repository";
                option.GetSmartSql = sp => sp.GetSmartSqlMapper("cinema_cmd");
                option.Filter = type => type.IsInterface && type.Name.EndsWith("Repository");
            });
        }

        public static void AddQuery(this IServiceCollection services, string conStr)
        {
            var qryConfig = new SmartSqlConfigOptions()
            {
                Database = new Database()
                {
                    DbProvider = new DbProvider()
                    {
                        Name = nameof(MySqlClientFactory),
                        ParameterPrefix = "@",
                        Type = typeof(MySqlClientFactory).AssemblyQualifiedName,
                    },
                    Write = new WriteDataSource()
                    {
                        Name = "Write-DB",
                        ConnectionString = conStr
                    }
                },
                Settings = new Settings()
                {
                    ParameterPrefix = "@",
                    IgnoreParameterCase = true,
                    IsWatchConfigFile = true
                },
                SmartSqlMaps = new List<SmartSqlMapSource>()
                {
                    new SmartSqlMapSource() { Path = "SqlMaps", Type = SmartSqlMapSource.ResourceType.Directory }
                },
                TypeHandlers = new List<TypeHandler>()
                {
                    new TypeHandler() { Handler = new JsonTypeHandler(), Name = "Json", Type = typeof(JsonTypeHandler).AssemblyQualifiedName }
                }
            };

            services.AddSmartSql(sp => new SmartSqlOptions()
            {
                Alias = "cinema_qry",
                LoggerFactory = sp.GetService<ILoggerFactory>(),
                ConfigLoader = new OptionConfigLoader(qryConfig, sp.GetService<ILoggerFactory>())
            });

            services.AddRepositoryFactory(sqlIdNamingConvert: (type, method) =>
            {
                int index = method.Name.IndexOf("By", StringComparison.Ordinal);
                if (index <= 0)
                    index = method.Name.IndexOf("To", StringComparison.Ordinal);

                return index <= 0 ? method.Name : method.Name.Substring(0, index);
            });
            services.AddRepositoryFromAssembly(option =>
            {
                option.AssemblyString = "Wizard.Cinema.QueryServices";
                option.GetSmartSql = sp => sp.GetSmartSqlMapper("cinema_qry");
                option.ScopeTemplate = "I{Scope}QueryService";
                option.Filter = type => type.IsInterface && type.Name.EndsWith("QueryService");
            });
        }
    }
}
