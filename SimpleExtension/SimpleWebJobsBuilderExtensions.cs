using System;
using Microsoft.Azure.WebJobs;

namespace SimpleExtension
{
    public static class SimpleWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddSimpleExtension(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<SimpleExtensionConfigProvider>();
            return builder;
        }
    }
}
