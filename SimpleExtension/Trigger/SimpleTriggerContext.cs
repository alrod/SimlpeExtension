using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExtension
{
    public class SimpleTriggerContext
    {
        public SimpleTriggerAttribute TriggerAttribute;

        public SimpleTriggerContext(SimpleTriggerAttribute attribute)
        {
            this.TriggerAttribute = attribute;
        }
    }
}
