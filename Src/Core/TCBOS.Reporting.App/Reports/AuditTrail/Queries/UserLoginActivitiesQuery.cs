using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Common.Interfaces;
using TCBOS.Reporting.App.Common.Models;
using TCBOS.Reporting.App.Reports.AuditTrial.Models;

namespace TCBOS.Reporting.App.Reports.AuditTrial
{
    public class UserLoginActivitiesQuery : BaseQuery, IRequest<RenderingResult>
    {
        public string CompanyID { get; set; }
        public string BranchID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LoginID { get; set; }

        public class CheckEmailExistQueryHandler : IRequestHandler<UserLoginActivitiesQuery, RenderingResult>
        {
            private readonly IMapper _mapper;
            private readonly IReport<UserLoginActivity> _report;

            public CheckEmailExistQueryHandler(IMapper mapper, IReport<UserLoginActivity> report)
            {
                _mapper = mapper;
                _report = report;
            }

            public async Task<RenderingResult> Handle(UserLoginActivitiesQuery request, CancellationToken cancellationToken)
            {
                return await _report.Rendering(request.RptFormat);
            }
        }
    }
}
