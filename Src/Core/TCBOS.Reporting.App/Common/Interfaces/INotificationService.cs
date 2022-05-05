using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Notifications.Models;

namespace TCBOS.Reporting.App.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
