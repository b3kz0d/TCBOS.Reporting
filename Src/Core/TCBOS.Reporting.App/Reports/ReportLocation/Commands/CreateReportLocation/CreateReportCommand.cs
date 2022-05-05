using AutoMapper;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCBOS.Reporting.Persistence;

namespace TCBOS.Reporting.App.Reports.ReportLocation.Commands.CreateReportLocation
{
    public class CreateReportLocationCommand : IRequest
    {
		public Guid ID { get; set; }
		public string ReportId { get; set; }
		[Column(TypeName = "jsonb")]
		public string ReportFilters { get; set; }
        public string ExportedReportPath { get; set; }

		public class CreateReportLocationCommandHandler : IRequestHandler<CreateReportLocationCommand>
        {
			private readonly TCBosReportDbContext _context;

			public CreateReportLocationCommandHandler(TCBosReportDbContext context)
            {
				_context = context;
            }

			public async Task<Unit> Handle(CreateReportLocationCommand request, CancellationToken cancellationToken)
			{
				var reportLocation = new Domain.Entities.ReportLocation()
				{
					ID = request.ID,
					ReportId = request.ReportId,
					ReportFilters = request.ReportFilters,
					ReportPath = request.ExportedReportPath,
					CreatedDate = DateTime.Now
				};

				_context.ReportLocations.Add(reportLocation);
				await _context.SaveChangesAsync();

				return Unit.Value;
            }
        }
	}
}
