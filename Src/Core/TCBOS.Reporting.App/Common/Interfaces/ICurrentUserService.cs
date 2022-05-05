using System;
using System.Collections.Generic;
using System.Text;

namespace TCBOS.Reporting.App.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }
    }
}
