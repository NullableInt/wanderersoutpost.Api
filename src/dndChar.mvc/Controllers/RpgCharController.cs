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

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("Wow it works");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Profile != null)
                {
                    return Ok(character);
                }
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> SetAll([FromRoute] Guid id, [FromBody] RpgCharModel dynamic)
        {
            dynamic.Profile.CharacterId = id;
            using (var session = Store.OpenAsyncSession())
            {
                await session.StoreAsync(dynamic, $"RpgChar/{id}");

                await session.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("{id}/Profile")]
        public async Task<IActionResult> GetProfile([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Profile != null)
                {
                    return Ok(character.Profile);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Profile")]
        public async Task<IActionResult> UpdateProfile([FromRoute] Guid id, [FromBody] Profile newProfile)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                sheet.Profile = newProfile;
            });
        }

        public async Task<IActionResult> UpdateRpgModel(Guid id, Action<RpgCharModel> updateMethod)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var characterSheet = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (characterSheet.Profile.CharacterId != id)
                {
                    return new ForbidResult();
                }

                updateMethod(characterSheet);

                await session.SaveChangesAsync();
            }
            return Ok();
        }
    }
}