using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Common.Interfaces;
using TCBOS.Reporting.App.Common.Models;
using TCBOS.Reporting.Domain.Entities;
using TCBOS.Reporting.Persistence;

namespace TCBOS.Reporting.App.Reports.Report.Queries.GetReportFile
{
    public class GetReportFileQuery:IRequest<RenderingResult>
    {
        public string ReportId { get; set; }
        [Column(TypeName = "jsonb")]
        public string ReportFilters { get; set; }

        public class CreateReportQueryHandler:IRequestHandler<GetReportFileQuery, RenderingResult>
        {
            private readonly TCBosReportDbContext _context;
            private readonly IReport<GetReportFileQuery> _report;
            private readonly IWebHostEnvironment _env;

            public CreateReportQueryHandler(TCBosReportDbContext context, IReport<GetReportFileQuery> report, IWebHostEnvironment env)
            {
                _context = context;
                _report = report;
                _env = env;
            }

            public async Task<RenderingResult> Handle(GetReportFileQuery request, CancellationToken cancellationToken)
            {
                var report = await _context.Reports.Where(r => r.ReportId == request.ReportId 
                                                                    && r.Enabled == true).SingleOrDefaultAsync();
                
                if(report == null)
                {
                    throw new Exception(string.Format("Report with ID={0} do not exited", request.ReportId));
                }

                var reportFilters = JsonSerializer.Deserialize<List<ReportFilter>>(request.ReportFilters);
                var reportPath = $"{_env.WebRootPath}/reports/{report.ReportId}/{report.ReportId}.trdp";
                return  await _report.Rendering(report.ReportFormat);

                
            }
        }
    }
}
