using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dndChar.Api
{
    [Route("CharacterSheet")]
    [ApiController]
    public class CharacterSheetController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Update")]
        public async Task Update(dynamic dynamic)
        {
            var test = JsonConvert.DeserializeObject<ApiAction>(dynamic);
            await Task.CompletedTask;
        }
    }

    public class ApiAction
    {
        public string Type { get; set; }
        public string Payload { get; set; }
    }
}
