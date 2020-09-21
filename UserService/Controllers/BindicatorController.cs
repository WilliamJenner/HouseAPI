namespace House.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using UserService.BLL.Bindicator.Interfaces;
    using UserService.BLL.Bindicator.Models;

    [ApiController]
    [Route("[controller]")]
    public class BindicatorController : ControllerBase
    {
        private readonly IBindicatorProvider _bindicatorProvider;

        public BindicatorController(IBindicatorProvider bindicatorProvider)
        {
            _bindicatorProvider = bindicatorProvider;
        }

        [HttpGet()]
        public async Task<BinLookup> Get()
        {
            try
            {
                return await _bindicatorProvider.Get();
            }
            catch(Exception e)
            {
                Log.Error("Error Getting Bin Information", e);
                throw;
            }
        }
    }
}
