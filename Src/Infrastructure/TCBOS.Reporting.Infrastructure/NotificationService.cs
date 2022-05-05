using System.Threading.Tasks;
using TCBOS.Reporting.App.Common.Interfaces;
using TCBOS.Reporting.App.Notifications.Models;

namespace TCBOS.Reporting.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
