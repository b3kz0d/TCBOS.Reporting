using System;
using System.Collections.Generic;
using System.Text;

namespace TCBOS.Reporting.App.Common.Models
{
    public sealed class RenderingResult
    {
        public string DocumentName { get; set; }
        public string MimeType { get; set; }
        public string Extension { get; set; }
        public Encoding Encoding { get; set; }
        public byte[] DocumentBytes { get; set; }
        public Exception[] Errors { get; set; }
        public bool HasErrors { get; set; }
        public int PageCount { get; set; }
        public bool DataAvailable { get; set; } = true;
    }
}
