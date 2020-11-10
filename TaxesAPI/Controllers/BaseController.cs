using System;
using Microsoft.AspNetCore.Mvc;
using TaxesLog;

namespace TaxesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly ILogger _consoleLogger;

        public BaseController(LoggerResolver loggerAccessor)
        {
            _consoleLogger = loggerAccessor("Console");
        }
        public IActionResult ResponseToUnauthorized()
        {
            _consoleLogger.Error("OK response.");
            return Unauthorized();
        }
        public IActionResult ResponseToNotFound()
        {
            _consoleLogger.Warning("NotFound response.");
            return NotFound();
        }
        public IActionResult ResponseToOK(Object content)
        {
            _consoleLogger.Info("OK response.");
            return Ok(content);
        }

    }
}
