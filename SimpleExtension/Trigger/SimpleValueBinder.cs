using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace SimpleExtension
{
    public  class SimpleValueBinder : IValueBinder
    {
        private object _value;

        public SimpleValueBinder(object value)
        {
            _value = value;
        }

        public Type Type => typeof(string);

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(_value);
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            _value = value;
            return Task.CompletedTask;
        }

        public string ToInvokeString()
        {
            return _value?.ToString();
        }
    }
}
