using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCBOS.Reporting.Persistence;

namespace TCBOS.Reporting.App.Reports.Report.Commands.DeleteReport
{
    public class DeleteReportCommand:IRequest
    {
        public int ID { get; set; }

        public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
        {
            private readonly TCBosReportDbContext _context;

            public DeleteReportCommandHandler(TCBosReportDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
            {
                var report = await _context.Reports.Where(r => r.ID == request.ID).SingleOrDefaultAsync();
                if (report != null)
                {
                    _context.Reports.Remove(report);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Format("Report with ID = {0} is not existed", request.ID));
                }
                return Unit.Value;
            }
        }
    }
}
