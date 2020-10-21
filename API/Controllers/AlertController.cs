namespace House.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DAL.DataTransferObjects;
    using HLL.Alert.Interfaces;
    using HLL.Alert.Models;
    using HLL.UniEvent.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using HLL.UniEvent.Models;
    using House.HLL.Common;

    [Route("[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertProvider _alertProvider;

        public AlertController(IAlertProvider alertProvider)
        {
            _alertProvider = alertProvider;
        }

        [HttpGet]
        public Task<IEnumerable<Alert>> Get()
        {
            return _alertProvider.Get();
        }

        [HttpGet]
        public Task<IEnumerable<Alert>> GetLatestAlerts()
        {
            return _alertProvider.Get();
        }

        [HttpGet("{id}")]
        public Task<IEnumerable<Alert>> Get(int id)
        {
            return _alertProvider.Get(id);
        }

        [HttpPost("get")]
        public Task<IEnumerable<Alert>> Get([FromBody] IEnumerable<int> ids)
        {
            return _alertProvider.Get(ids);
        }

        [HttpPost]
        public void Post([FromBody] NewAlert newAlert)
        {
            _alertProvider.Post(newAlert);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NewAlert newAlert)
        {
            _alertProvider.Put(id, newAlert);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _alertProvider.Delete(id);
        }
    }
}
