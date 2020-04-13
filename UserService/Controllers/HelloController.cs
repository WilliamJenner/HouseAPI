using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.BLL;
using UserService.BLL.Interfaces;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;
        private readonly IHello _hello;

        public HelloController(ILogger<HelloController> logger, IHello hello)
        {
            _logger = logger;
            _hello = hello;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _hello.Get();
        }
    }
}
