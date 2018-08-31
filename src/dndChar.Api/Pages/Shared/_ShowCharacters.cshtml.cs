using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dndChar;
using dndChar.Database;

namespace dndChar.Api.Pages.Shared
{
    public class _ShowCharactersModel : PageModel
    {
        private readonly dndChar.Database.ApplicationDbContext _context;

        public _ShowCharactersModel(dndChar.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CharacterSheet> CharacterSheet { get;set; }

        public async Task OnGetAsync()
        {
            CharacterSheet = await _context.Characters.ToListAsync();
        }
    }
}
