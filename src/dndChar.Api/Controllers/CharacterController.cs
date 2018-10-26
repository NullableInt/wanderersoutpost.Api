using System;
using System.Linq;
using System.Threading.Tasks;

using dndChar.Api.Pages;
using dndChar.Database;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dndChar.Api.Controllers
{
    [Route("/character")]
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public CharacterController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(HttpContext.User);
            if (!this.applicationDbContext.Characters.Any(entry => entry.OwnerId == user.Id))
            {
                var newCharacterSheet = CharacterSheet.CreateCharacterSheet(user.Id, false);
                var dbEntry = new CharacterSheetDbEntry
                {
                    CharacterSheet = newCharacterSheet,
                    OwnerId = user.Id,
                    CharacterSheetId = Guid.NewGuid().ToString()
                };
                await this.applicationDbContext.Characters.AddAsync(dbEntry);
                await this.applicationDbContext.SaveChangesAsync();
            }
            return View();
        }
    }
}