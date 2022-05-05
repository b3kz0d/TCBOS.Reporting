using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TCBOS.Reporting.App.Common.Mappings;


namespace TCBOS.Reporting.App.Reports.Report.Queries.GetReportsList
{
    public class ReportVm:IMapFrom<Domain.Entities.Report>
    {
		public Int64 ID { get; set; }
		public string ReportId { get; set; }
		public string ReportName { get; set; }
		public string CompId { get; set; }
		public string Module { get; set; }
		public string ReportPath { get; set; }
		public string ReportFormat { get; set; }
		public string ReportTemplate { get; set; }

		[Column(TypeName = "jsonb")]
		public string ReportFilters { get; set; }

		public void Mapping(Profile profile)
        {
			profile.CreateMap<Domain.Entities.Report, ReportVm>();
		}
	}
}
