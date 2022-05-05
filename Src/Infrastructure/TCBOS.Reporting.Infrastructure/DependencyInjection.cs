
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TCBOS.Reporting.App.Common.Interfaces;

namespace TCBOS.Reporting.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            return services;
        }
    }
}
