using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using dndChar.Database;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dndChar.Api.Views.Character
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext context;
        private UserManager<IdentityUser> userManager;
        public IList<CharacterSheetDbEntry> CharacterSheet { get; set; }

        public  IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager) 
        {
            this.context = context;
            this.userManager = userManager;
            ViewData["Title"] = "Characters page";
        }

        public async Task OnGetAsync()
        {
            var userId = await this.userManager.GetUserAsync(HttpContext.User);
            CharacterSheet = this.context.Characters.Include(entry => entry.OwnerId == userId.Id).ToList();
        }
    }
}