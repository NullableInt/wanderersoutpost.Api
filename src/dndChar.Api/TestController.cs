using dndChar.Api.Util;
using Microsoft.AspNetCore.Mvc;

namespace dndChar.Api
{
    public class TestController : Controller
    {
        [HttpPost("test")]
        [Operation("test-type")]
        public IActionResult Test()
        {
            return new OkObjectResult("This is the test function");
        }

        [HttpPost("test")]
        [Operation("test-type-other")]
        public IActionResult Test2()
        {
            return new OkObjectResult("This is the OTHER test function");
        }
    }
}
