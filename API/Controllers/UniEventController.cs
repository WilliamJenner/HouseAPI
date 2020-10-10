namespace House.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DAL.DataTransferObjects;
    using HLL.UniEvent.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using HLL.UniEvent.Models;
    using House.HLL.Common;

    [Route("[controller]")]
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

        [HttpPost("get")]
        public Task<IEnumerable<UniEvent>> Get([FromBody] IEnumerable<int> ids)
        {
            return _uniEventProvider.Get(ids);
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

        [HttpPost("GetMultipleTimetables")]
        public void RetrieveTimetableRowsBatched([FromBody] List<KeyValue>cookies)
        {
            cookies.ForEach(x=>_uniEventProvider.RetrieveTimetableRows(x));
        }

        [HttpPost("GetTimetable")]
        public void RetrieveTimetableRows([FromBody] KeyValue cookie) =>
            RetrieveTimetableRowsBatched(new List<KeyValue>{ cookie });

        [HttpGet("DeDupe")]
        public void RunDeDupe()
        {
            _uniEventProvider.RunDedupe();
        }
        
            
        

    }
}
