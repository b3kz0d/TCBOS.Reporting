using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCBOS.Reporting.Domain.Entities
{
    public class Report
	{
		public Int64 ID { get; set; }
		public string ReportId { get; set; }
		public string ReportName { get; set; }
		public string CompId { get; set; }
		public string Module { get; set; }
		public string ReportPath { get; set; }
		public string ReportFormat { get; set; }
		public bool Enabled { get; set; }
		public string ReportTemplate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }

		[Column(TypeName = "jsonb")]
		public string ReportFilters { get; set; }
	}
}
