using Microsoft.Extensions.DependencyInjection;
using Wizard.Cinema.Smartsql;

namespace Wizard.Cinema.Application.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddSmartSqlStorage();
        }
    }
}
