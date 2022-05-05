using System;
using System.Collections.Generic;
using System.Text;

namespace TCBOS.Reporting.Telerik
{  
    public static class ReportMapping
    {
        public static IDictionary<string, string> ReportPath = new Dictionary<string, string>()
        {
            {typeof(App.Reports.AuditTrial.Models.UserLoginActivity).Name, "Reports\\AuditTrail\\UserLoginActivities.trdp"}
        };
        
    }
}
