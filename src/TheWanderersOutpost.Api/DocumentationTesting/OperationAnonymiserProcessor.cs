using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using System.Linq;
using System.Reflection;
using TheWanderersOutpost.Api.DocumentationTesting;

namespace TheWanderersOutpost.Api
{
    public class OperationAnonymiserProcessor : IOperationProcessor
    {
        public bool Process(OperationProcessorContext operationProcessorContext)
        {
            if (!(operationProcessorContext is AspNetCoreOperationProcessorContext context))
            {
                return false;
            }

            var operationTypes = context.MethodInfo
                .GetCustomAttributes()
                .Where(m =>
                    m.GetType().IsAssignableFrom(typeof(ProducesOperationsAttribute)) ||
                    m.GetType().IsAssignableFrom(typeof(ProducesOperationsWithTypeAttribute)))
                .ToList();

            if (!operationTypes.Any())
                return true;

            return true;
        }
    }
}