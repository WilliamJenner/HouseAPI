namespace House.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DAL.DataTransferObjects;
    using HLL.UniEvent.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using HLL.UniEvent.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class UniEventController : ControllerBase
    {
        private readonly IUniEventProvider _uniEventProvider;

        public UniEventController(IUniEventProvider uniEventProvider)
        {
            _uniEventProvider = uniEventProvider;
        }

        [HttpGet]
        public Task<IEnumerable<UniEvent>> Get()
        {
            return _uniEventProvider.Get();
        }

        [HttpGet("{id}", Name = "Get")]
        public Task<IEnumerable<UniEvent>> Get(int id)
        {
            return _uniEventProvider.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] NewUniEvent newEvent)
        {
            _uniEventProvider.Post(newEvent);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NewUniEvent newEvent)
        {
            _uniEventProvider.Put(id, newEvent);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _uniEventProvider.Delete(id);
        }
    }
}
