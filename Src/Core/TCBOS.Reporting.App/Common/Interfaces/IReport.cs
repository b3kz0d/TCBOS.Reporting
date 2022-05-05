using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Common.Models;

namespace TCBOS.Reporting.App.Common.Interfaces
{
    public interface IReport<T>
    {
        List<T> DataSource { get; set; }

        Dictionary<string, object> Parameters { get; set; }

        SortedDictionary<string, object> CsvCustomHeaders { get; set; }

        Task<RenderingResult> Rendering(string format);
    }
}
