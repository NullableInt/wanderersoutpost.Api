using System.Linq;
using dndChar.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dndCharApi.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        public IMongoDatabase MongoDb { get; set; }
        public MongoConfig MongoConfig { get; }

        public ApiController(DocumentStoreHolder holder, IOptions<MongoConfig> options)
        {
            MongoDb = holder.Store.GetDatabase("RpgCharModelDb");
            MongoConfig = options.Value;
        }

        [HttpGet]
        [Route("public")]
        public IActionResult Public()
        {
            return Json(new
            {
                Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
            });
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        public IActionResult Private()
        {
            return Json(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated to see this."
            });
        }

        [HttpGet]
        [Route("private-scoped")]
        [Authorize("read:messages")]
        public IActionResult Scoped()
        {
            return Json(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
            });
        }


        /// <summary>
        /// This is a helper action. It allows you to easily view all the claims of the token
        /// </summary>
        /// <returns></returns>
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Json(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }

        [HttpGet("Database")]
        public IActionResult Database()
        {
            return Json(MongoConfig);
        }
    }
}
