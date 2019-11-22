using System.Collections.Generic;

namespace TheWanderersOutpost.Api.DocumentationTesting
{
    internal class TestOperationResult
    {
        public PaymentOrderWithId Paymentorder { get; internal set; }
        public List<Operations> Operations { get; internal set; }
    }
}