using dndChar.Api.Util;
using Microsoft.AspNetCore.Mvc;

namespace dndChar.Api
{
    public class TestController : Controller
    {
        [HttpPost("test")]
        [Action("test-type")]
        public IActionResult Test()
        {
            return new OkObjectResult("This is the test function");
        }

        [HttpPost("test")]
        [Action("test-type-other")]
        public IActionResult Test2()
        {
            return new OkObjectResult("This is the OTHER test function");
        }
    }
}
