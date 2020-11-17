namespace House.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CronJobs;
    using DAL.DataTransferObjects;
    using HLL.Alert.Interfaces;
    using HLL.Alert.Models;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [Route("[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertProvider _alertProvider;
        private readonly IAutoNewsConsumer _autoNewsConsumer;

        public AlertController(IAlertProvider alertProvider, IAutoNewsConsumer autoNewsConsumer)
        {
            _alertProvider = alertProvider;
            _autoNewsConsumer = autoNewsConsumer;
        }

        [HttpGet("all")]
        public Task<IEnumerable<Alert>> Get()
        {
            try
            {
                return _alertProvider.Get();
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception getting all alerts");
                throw;
            }
            
        }

        [HttpGet("GetLatest")]
        public Task<IEnumerable<Alert>> GetLatestAlerts()
        {
            try
            {
                return _alertProvider.Get();
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception getting latest alerts");
                throw;
            }
            
        }

        [HttpGet("ConsumeNews/{articles}")]
        public IActionResult ComsumeNews([FromRoute] int articles)
        {
            try
            {
                _ = Task.Run(() => _autoNewsConsumer.Consume(articles));
                return Ok($"Started {nameof(AutoConsumeNews)}");
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception consuming news");
                throw;
            }
            ;
        }

        [HttpGet("{id}")]
        public Task<IEnumerable<Alert>> Get(int id)
        {
            try
            {
                return _alertProvider.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception getting alert");
                throw;
            }
            
        }

        [HttpPost("GetMultiple")]
        public Task<IEnumerable<Alert>> Get([FromBody] IEnumerable<int> ids)
        {
            try
            {
                return _alertProvider.Get(ids);
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception getting alerts");
                throw;
            }
            
        }

        [HttpPost("NewAlert")]
        public void Post([FromBody] NewAlert newAlert)
        {
            try
            {
                _alertProvider.Post(newAlert);
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception adding alert");
                throw;
            }
            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NewAlert newAlert)
        {
            try
            {
                _alertProvider.Put(id, newAlert);
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception updating alert");
                throw;
            }
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _alertProvider.Delete(id);
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception deleting alert");
                throw;
            }
            
        }
    }
}
