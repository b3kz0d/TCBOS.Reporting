using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCBOS.Reporting.Domain.Entities
{
    public class ReportLocation
    {
		public Guid ID { get; set; }
		public string ReportId { get; set; }
		[Column(TypeName = "jsonb")]
		public string ReportFilters { get; set; }
		public string ReportPath { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
