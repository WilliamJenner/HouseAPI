namespace House.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;
    using House.BLL.Interfaces;

    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;
        private readonly IHello _hello;

        public HelloController(ILogger<HelloController> logger, IHello hello)
        {
            this._logger = logger;
            this._hello = hello;
        }

        [HttpGet("lol")]
        public async Task<string> Get()
        {
            return await this._hello.Get();
        }
    }
}
