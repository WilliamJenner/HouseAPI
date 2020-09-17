namespace House.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using House.HLL.Models;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;
    using House.HLL.Interfaces;

    [ApiController]
    [Route("[controller]")]
    public class BindicatorController : ControllerBase
    {
        private readonly IBindicatorProvider _bindicatorProvider;

        public BindicatorController(IBindicatorProvider bindicatorProvider)
        {
            this._bindicatorProvider = bindicatorProvider;
        }

        [HttpGet()]
        public async Task<BinLookupDto> Get()
        {
            return await this._bindicatorProvider.Get();
        }
    }
}
