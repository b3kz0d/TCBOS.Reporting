using Microsoft.AspNetCore.Http;

namespace TCBOS.Reporting.API.ViewModels.Report
{
    public class UploadReportViewModel
    {
        public IFormFile RptFile { get; set; }

		public string ReportName { get; set; }
		public string CompId { get; set; }
		public string Module { get; set; }
		public string ReportFilters { get; set; }
		public string ReportFormat { get; set; }
	}
}
