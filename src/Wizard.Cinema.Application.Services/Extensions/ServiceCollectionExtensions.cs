using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Infrastructures.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Wizard.Cinema.Smartsql;

namespace Wizard.Cinema.Application.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSmartSqlStorage(configuration);

            //自动注册
            foreach (TypeInfo implType in Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.GetCustomAttribute<ImplAttribute>() != null))
            {
                ImplAttribute attr = implType.GetCustomAttribute<ImplAttribute>();
                IEnumerable<Type> interfaceTypes = implType.ImplementedInterfaces;

                if (attr.InterfaceType != null)
                {
                    services.TryAdd(new ServiceDescriptor(attr.InterfaceType, implType, attr.Lifetime));
                }
                else
                {
                    foreach (Type interfaceType in interfaceTypes)
                    {
                        services.TryAdd(new ServiceDescriptor(interfaceType, implType, attr.Lifetime));
                    }
                }
            }
        }
    }
}
