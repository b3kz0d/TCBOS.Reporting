using Microsoft.EntityFrameworkCore;
using TCBOS.Reporting.Domain.Entities;

namespace TCBOS.Reporting.Persistence
{
    public class TCBosReportDbContext: DbContext
    {
        public TCBosReportDbContext(DbContextOptions<TCBosReportDbContext> options) : base(options) { }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportLocation> ReportLocations { get; set; }
    }
}
