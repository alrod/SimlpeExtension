using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace SimpleExtension
{
    internal class SimpleTriggerBinding : ITriggerBinding
    {
        private readonly SimpleTriggerContext _context;
        public SimpleTriggerBinding(SimpleTriggerContext context)
        {
            _context = context;
        }

        public Type TriggerValueType => typeof(string);

        public IReadOnlyDictionary<string, Type> BindingDataContract => new Dictionary<string, Type>();

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            var valueProvider = new SimpleValueBinder(value);
            var bindingData = new Dictionary<string, object>();
            var triggerData = new TriggerData(valueProvider, bindingData);

            return Task.FromResult<ITriggerData>(triggerData);
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            var executor = context.Executor;
            var listener = new SimpleListener(executor, _context);

            return Task.FromResult<IListener>(listener);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new TriggerParameterDescriptor
            {
                Name = "Simple",
                DisplayHints = new ParameterDisplayHints
                {
                    Prompt = "Simple",
                    Description = "Simple message trigger"
                }
            };
        }
    }
}
