using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheWanderersOutpost.Api.DocumentationTesting
{
    public sealed class ProducesOperationsWithTypeAttribute : ProducesResponseTypeAttribute
    {
        public List<string> Operations { get; } = new List<string>();

        public ProducesOperationsWithTypeAttribute() : base(200)
        {
        }

        public ProducesOperationsWithTypeAttribute(Type type, params string[] operations) : base(type, 200)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (operations is null)
            {
                throw new ArgumentNullException(nameof(operations));
            }

            Operations = operations.ToList();
        }

        public ProducesOperationsWithTypeAttribute(Type type) : base(type, 200)
        {
        }
    }
}