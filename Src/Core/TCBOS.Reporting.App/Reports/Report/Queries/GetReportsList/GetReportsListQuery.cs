using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Reports.Report.Queries.GetReportsList;
using TCBOS.Reporting.Persistence;

namespace TCBOS.Reporting.App.Reports.Report.Queries.GetListReports
{
    public class GetReportsListQuery:IRequest<IEnumerable<ReportVm>>
    {

        public class GetReportsListQueryHandler:IRequestHandler<GetReportsListQuery, IEnumerable<ReportVm>>
        {
            private readonly TCBosReportDbContext _context;
            private readonly IMapper _mapper;

            public GetReportsListQueryHandler(TCBosReportDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<IEnumerable<ReportVm>> Handle(GetReportsListQuery request, CancellationToken cancellationToken)
            {
                var reports = _context.Reports.Where(r => r.Enabled == true);
                var reportVms = _mapper.Map<IEnumerable<ReportVm>>(reports);

                return await Task.FromResult(reportVms);
            }
        }
    }
}
