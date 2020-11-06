using LJS.Core.IServices;
using LJS.Core.Model;
using LJS.Core.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LJS.Core.Extensions.CustomApiVersion;

namespace LJS.Core.Api.Controllers.v2
{
    /// <summary>
    /// 测试专用
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [CustomRoute(ApiVersions.v2)]
    public class TestController : ControllerBase
    {
        readonly ITestServices _TestServices;
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger, ITestServices testServices)
        {
            _logger = logger;
            _TestServices = testServices;
        }

        [HttpGet]
        public async Task<MessageModel<List<TestModel>>> GetAll()
        {
            return new MessageModel<List<TestModel>>()
            {
                msg = "获取成功",
                success = true,
                response = await _TestServices.GetTests()
            };
        }
    }
}
