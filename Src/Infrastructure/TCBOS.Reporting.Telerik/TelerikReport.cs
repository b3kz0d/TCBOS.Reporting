using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBOS.Reporting.App.Common.Interfaces;
using TCBOS.Reporting.Telerik;
using RenderingResult = TCBOS.Reporting.App.Common.Models.RenderingResult;
//using Report = Telerik.Reporting.Report;
//using ReportProcessing = Telerik.Reporting.Processing;

namespace TCBOS.Reporting.Telerik2
{
    public class TelerikReport<T> : IReport<T>
    {
        public List<T> DataSource { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        public SortedDictionary<string, object> CsvCustomHeaders { get; set; } = new SortedDictionary<string, object>();

        public Task<RenderingResult> Rendering(string format)
        {
            throw new NotImplementedException();
        }
    }
}
