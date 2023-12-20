using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using SimpleExtension;
using Microsoft.Azure.WebJobs;

namespace WebJobsApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.UseEnvironment(EnvironmentName.Development);
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddSimpleExtension();
            });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }

    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([SimpleTrigger(2000)] string eventContent, ILogger log)
        {
            Console.WriteLine(eventContent);
        }
    }
}