using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using SimpleExtension;

[assembly: WebJobsStartup(typeof(SimpleExtensionStartup))]
namespace SimpleExtension
{
    public class SimpleExtensionStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            // Add Simple extension
            builder.AddSimpleExtension();
        }
    }
}
