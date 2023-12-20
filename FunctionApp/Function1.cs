using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SimpleExtension;

namespace FunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([SimpleTrigger(3000)] string eventContent, ILogger log)
        {
            Console.WriteLine(eventContent);
        }
    }
}