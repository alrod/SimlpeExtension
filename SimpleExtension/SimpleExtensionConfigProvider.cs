using Microsoft.Azure.WebJobs.Host.Config;

namespace SimpleExtension
{
    public class SimpleExtensionConfigProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            // Add trigger first
            var triggerRule = context.AddBindingRule<SimpleTriggerAttribute>();
            triggerRule.BindToTrigger(new SimpleTriggerBindingProvider(this));

            // Here we can add input/outptu binding
        }

        public SimpleTriggerContext CreateContext(SimpleTriggerAttribute attribute)
        {
            return new SimpleTriggerContext(attribute);
        }
    }
}
