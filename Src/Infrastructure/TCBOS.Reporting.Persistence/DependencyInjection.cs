using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TCBOS.Reporting.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TCBosReportDbContext>(opts => {
                opts.UseSqlServer(configuration.GetConnectionString("TCBosReportDb"));
            });
            return services;
        }
    }
}
