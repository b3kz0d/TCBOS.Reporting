using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TCBOS.Reporting.App.Reports.AuditTrial;

namespace TCBOS.Reporting.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditTrailController : BaseController
    {
        private readonly ILogger<AuditTrailController> _logger;
        private IHttpContextAccessor _accessor;
        public AuditTrailController(ILogger<AuditTrailController> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Index()
        {
            return Ok("TCBOS.Reporting.API");
        }

        [HttpPost("UserLoginActivities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserLoginActivities([FromBody]UserLoginActivitiesQuery query)
        {
            var result = await Mediator.Send(query);
            if (result.HasErrors)
                return BadRequest();
            return File(result.DocumentBytes, result.MimeType, result.DocumentName+"."+ result.Extension);
        }

    }
}
