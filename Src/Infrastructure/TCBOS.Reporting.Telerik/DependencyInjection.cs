using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCBOS.Reporting.App.Common.Interfaces;

namespace TCBOS.Reporting.Telerik2
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTelerikReporting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(IReport<>), typeof(TelerikReport<>));

            return services;
        }
    }
}
