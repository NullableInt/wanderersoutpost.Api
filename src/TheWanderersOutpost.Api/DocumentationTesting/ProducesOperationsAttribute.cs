using System;
using System.Collections.Generic;
using System.Linq;

namespace TheWanderersOutpost.Api.DocumentationTesting
{
    public sealed class ProducesOperationsAttribute : Attribute
    {
        public List<string> Operations { get; } = new List<string>();

        public ProducesOperationsAttribute(params string[] operations)
        {
            if (operations is null)
            {
                throw new ArgumentNullException(nameof(operations));
            }

            Operations = operations.ToList();
        }
    }
}