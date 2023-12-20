using System;
using Microsoft.Azure.WebJobs.Description;

namespace SimpleExtension
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class SimpleTriggerAttribute: Attribute
    {
        public SimpleTriggerAttribute(int timeIntervalInSecs) 
        {
            TimeIntervalInSecs = timeIntervalInSecs;
        }

        public int TimeIntervalInSecs { get; set; }
    }
}
