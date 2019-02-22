using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dndChar.Api.Util;
using dndChar.Database;
using dndChar.mvc.Models.RpgChar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;

namespace dndChar.mvc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RpgCharController : Controller
    {
        public IDocumentStore Store { get; set; }
        
        public RpgCharController(DocumentStoreHolder holder)
        {
            Store = holder.Store;
        }

        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTreasures([FromRoute] Guid characterSheetId, [FromBody] RpgCharModel dynamic)
        {
            dynamic.Profile.CharacterId = characterSheetId;
            using (var session = Store.OpenAsyncSession())
            {
                await session.StoreAsync(dynamic, "RpgChar/" + characterSheetId);

                await session.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("Wow it works");
        }

        public async Task<IActionResult> UpdateRpgModel(string characterSheetId, Action<RpgCharModel> updateMethod)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var characterSheet = await session.LoadAsync<RpgCharModel>("RpgChar/" + characterSheetId);
                if (characterSheet.Profile.CharacterId != Guid.Parse(characterSheetId))
                {
                    return new ForbidResult();
                }

                updateMethod(characterSheet);

                await session.SaveChangesAsync();
            }
            return Ok();
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
    }
}