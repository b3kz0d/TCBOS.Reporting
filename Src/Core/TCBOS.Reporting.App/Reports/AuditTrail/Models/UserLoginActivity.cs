using System;
using System.Collections.Generic;
using System.Text;

namespace TCBOS.Reporting.App.Reports.AuditTrial.Models
{
    public class UserLoginActivity
    {
        public Guid GUIID { get; set; }
        public long ID { get; set; }
        public long UserUID { get; set; }
        public string LoginID { get; set; }
        public DateTime? LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
        public string UsrMACAddress { get; set; }
        public string InternalIP { get; set; }
        public string GateWayIP { get; set; }
        public string AppVersion { get; set; }
        public string CompanyID { get; set; }
        public string BranchID { get; set; }
        public string LogType { get; set; }
        public string LogoutReason { get; set; }
        public string LogoutReasonDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? SwitchBranchDate { get; set; }
        public string SwitchCompanyID { get; set; }
        public string SwitchBranchID { get; set; }
    }
}
