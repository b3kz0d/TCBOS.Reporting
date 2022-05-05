using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Common.Mappings;
using TCBOS.Reporting.Persistence;

namespace TCBOS.Reporting.App.Reports.Report.Commands.CreateReport
{
    public class CreateOrUpdateReportCommand : IRequest, IMapFrom<Domain.Entities.Report>
    {
		public string ReportId { get; set; }
		public string ReportName { get; set; }
		public string CompId { get; set; }
		public string Module { get; set; }
		public string ReportPath { get; set; }
		public string ReportFormat { get; set; }
		public bool Enabled { get; set; }
		public string ReportTemplate { get; set; }
		public string ReportFilters { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateOrUpdateReportCommand, Domain.Entities.Report>()
				   .ForMember(des => des.Enabled, opt => opt.MapFrom(src => true))
				   .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
				   .ForMember(des => des.ReportFilters, opt=> opt.MapFrom(src => 
																		string.IsNullOrEmpty(src.ReportFilters)?"[]":src.ReportFilters));
		}

		public class CreateOrUpdateReportCommandHandler : IRequestHandler<CreateOrUpdateReportCommand>
        {
			private readonly TCBosReportDbContext _context;
			private readonly IMapper _mapper;

			public CreateOrUpdateReportCommandHandler(TCBosReportDbContext context, IMapper mapper)
            {
				_context = context;
				_mapper = mapper;
            }

			public async Task<Unit> Handle(CreateOrUpdateReportCommand request, CancellationToken cancellationToken)
            {
				var dbReport = _context.Reports.Where(r => r.ReportId == request.ReportId).SingleOrDefault();

                if (dbReport != null)
                {
					_mapper.Map(request, dbReport);
					dbReport.ModifiedDate = DateTime.Now;
                }
                else
                {
					var report = _mapper.Map<Domain.Entities.Report>(request);
					_context.Reports.Add(report);
				}

				await _context.SaveChangesAsync(cancellationToken);

				return Unit.Value;

            }
        }
	}
}
