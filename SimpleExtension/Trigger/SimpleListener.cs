using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;

namespace SimpleExtension
{
    public class SimpleListener : IListener
    {
        private readonly ITriggeredFunctionExecutor _executor;
        private Timer _timer;
        private readonly SimpleTriggerContext _context;

        public SimpleListener(ITriggeredFunctionExecutor executor, SimpleTriggerContext context)
        {
            _executor = executor;
            _context = context;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, 0, _context.TriggerAttribute.TimeIntervalInSecs);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Cancel()
        {
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private async void DoWork(object state)
        {
            var triggerData = new TriggeredFunctionData
            {
                TriggerValue = $"New simple event emmited at {DateTime.Now.TimeOfDay}"
            };

            await _executor.TryExecuteAsync(triggerData, CancellationToken.None);
        }
    }
}
