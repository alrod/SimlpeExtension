using System;
using Microsoft.Azure.WebJobs.Host.Triggers;
using System.Threading.Tasks;
using System.Reflection;

namespace SimpleExtension
{
    public class SimpleTriggerBindingProvider : ITriggerBindingProvider
    {
        private SimpleExtensionConfigProvider _provider;

        public SimpleTriggerBindingProvider(SimpleExtensionConfigProvider provider)
        {
            _provider = provider;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            var parameter = context.Parameter;
            var attribute = parameter.GetCustomAttribute<SimpleTriggerAttribute>(false);

            if (attribute == null) return Task.FromResult<ITriggerBinding>(null);
            if (parameter.ParameterType != typeof(string)) throw new InvalidOperationException("Invalid parameter type");

            var triggerBinding = new SimpleTriggerBinding(_provider.CreateContext(attribute));

            return Task.FromResult<ITriggerBinding>(triggerBinding);
        }
    }
}
