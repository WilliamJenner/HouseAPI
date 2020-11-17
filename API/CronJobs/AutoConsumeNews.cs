namespace House.API.CronJobs
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using HLL.Alert.Interfaces;
    using Microsoft.Extensions.Hosting;
    using NCrontab;
    using Serilog;

    public class AutoConsumeNews : BackgroundService
    {
        private readonly CrontabSchedule _schedule;
        private readonly IAutoNewsConsumer _autoNewsConsumer;
        private DateTime _nextRun;

        private string Schedule => "0 9,18 * * 1-5"; //11:59 every week day

        public AutoConsumeNews(IAutoNewsConsumer autoNewsConsumer)
        {
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = false });
            _autoNewsConsumer = autoNewsConsumer;
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information($"Stopping {nameof(AutoConsumeNews)}");

            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                if (DateTime.Now > _nextRun)
                {
                    Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private void Process()
        {
            _autoNewsConsumer.Consume();
        }
    }
}
