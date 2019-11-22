using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheWanderersOutpost.Api.DocumentationTesting;

namespace TheWanderersOutpost.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChaosController : Controller
    {
        /// <summary>
        /// Checks that the api is live
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("public")]
        public IActionResult Public()
        {
            return Json(new
            {
                Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
            });
        }

        [HttpPost("test")]
        [ProducesOperations("view-paymentOrder", "review-payment", "unlicky-test")]
        [ProducesOperationsWithType(typeof(TestOperationResult), "view-paymentOrder", "review-payment", "unlicky-test")]
        public IActionResult Test([FromBody] TestOperation testOperation)
        {
            if (!testOperation.Operation.Equals("woah-dude"))
            {
                throw new InvalidOperationException("Woah dude, this is like not the right place bruh");
            }

            return Json(new TestOperationResult
            {
                Paymentorder = new PaymentOrderWithId
                {
                    Id = "/psp/paymentorders/b80be381-b572-4f1e-9691-08d5dd095bc4"
                },
                Operations = new List<Operations> {
                    new Operations {
                        Href = new Uri("https://ecom.externalintegration.payex.com/paymentmenu/core/scripts/client/px.paymentmenu.client.js?token=fantasticalTokenHereBruh&culture=sv-SE"),
                        Rel = "view-paymentorder",
                        Method = "GET",
                        ContentType = "application/javascript"
                    }
                }
            });
        }
    }
}
