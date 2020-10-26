namespace House.API.CronJobs
{
    using Microsoft.Extensions.Hosting;
    using NCrontab;
    using System;
    using System.Threading.Tasks;
    using System.Threading;
    using House.HLL.Alert;
    using Serilog;

    public class AutoConsumeNews : IHostedService, IDisposable
    {
        private readonly CrontabSchedule _schedule;
        private readonly IAutoNewsConsumer _autoNewsConsumer;

        private string Schedule => "0 0 8,17 ? * * *"; //Runs every day at 8am and 17pm

        public AutoConsumeNews(IAutoNewsConsumer autoNewsConsumer)
        {
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _autoNewsConsumer = autoNewsConsumer;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("stop");

            return Task.CompletedTask;
        }
        public Task StartAsync(CancellationToken stoppingToken)
        {
            Log.Information("News Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void Process()
        {
            _autoNewsConsumer.Consume();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
