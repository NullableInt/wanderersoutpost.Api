using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using dndChar.Database;

using Microsoft.AspNetCore.Mvc;
using dndChar.mvc.Models;
using dndChar.mvc.Viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;

using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace dndChar.mvc.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private IDocumentStore Store;


        public HomeController(UserManager<IdentityUser> userManager, DocumentStoreHolder holder)
        {
            this._userManager = userManager;
            Store = holder.Store;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await this._userManager.GetUserAsync(HttpContext.User);
            var sheets = new List<string>();
            if (user != null)
            {
                var userid = Guid.Parse(user.Id);
                using (var session = Store.OpenAsyncSession())
                {
                    var foundsheets = await session.Advanced.AsyncDocumentQuery<CharacterSheet>().WhereEquals(x => x.ServerState.appUserId, userid).ToListAsync();
                    if (!foundsheets.Any())
                    {
                        var shee = CharacterSheet.CreateCharacterSheet(userid, false);
                        await session.StoreAsync(shee);
                        await session.SaveChangesAsync();
                    }
                    foreach (var characterSheet in foundsheets)
                    {
                        sheets.Add(characterSheet.ToString());
                    }
                }
            }

            return View(new CharacterSheetsViewModel()
            {
                CharacterSheets = sheets
            });
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
