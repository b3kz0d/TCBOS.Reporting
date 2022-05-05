using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Common.Mappings;
using TCBOS.Reporting.Persistence;

namespace TCBOS.Reporting.App.Reports.Report.Commands.UpdateReport
{
    public class UpdateReportCommand : IRequest, IMapFrom<Domain.Entities.Report>
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

		[Column(TypeName = "jsonb")]
		public string ReportFilters { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateReportCommand, Domain.Entities.Report>()
                   .ForMember(des => des.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));
        }

        public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand>
        {
            private readonly TCBosReportDbContext _context;
            private readonly IMapper _mapper;

            public UpdateReportCommandHandler(TCBosReportDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
            {
                var report = await _context.Reports.Where(r => r.ID == request.ID).SingleOrDefaultAsync();
                if (report != null)
                {
                    _mapper.Map(request, report);

                    _context.Reports.Update(report);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Format("Report with ID = {0} do not existed", request.ID));
                }
                return Unit.Value;
            }
        }
	}
}
