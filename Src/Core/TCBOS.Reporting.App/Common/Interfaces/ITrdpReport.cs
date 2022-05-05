using System.Collections.Generic;
using TCBOS.Reporting.App.Common.Models;

namespace TCBOS.Reporting.App.Common.Interfaces
{
    public interface ITrdpReport
    {
        SortedDictionary<string, object> CsvCustomHeaders { get; set; }

        RenderingResult Rendering(string reportPath, IEnumerable<ReportFilter> reportFilters, string format);
    }
}
