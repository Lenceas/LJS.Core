using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using static LJS.Core.Extensions.CustomApiVersion;

namespace LJS.Core.Api.Controllers.v2
{
    [Produces("application/json")]
    [ApiController]
    [CustomRoute(ApiVersions.v2)]
    public class TestController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public TestController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


    }
}
