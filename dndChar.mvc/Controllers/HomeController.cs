using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using dndChar.Database;
using dndChar;
using dndChar.mvc.Data;

using Microsoft.AspNetCore.Mvc;
using dndChar.mvc.Models;
using dndChar.mvc.Viewmodels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace dndChar.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext applicationDbContext)
        {
            this.userManager = userManager;
            this.applicationDbContext = applicationDbContext;
        }
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
            var sheets = new List<string> { "sheet1", "sheet2", "sheet3"};

            return View(new CharacterSheetsViewModel()
            {
                CharacterSheets = sheets
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
