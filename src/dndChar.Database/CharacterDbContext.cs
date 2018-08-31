using dndChar.Models;
using Microsoft.EntityFrameworkCore;

namespace dndChar.Database
{
    public class CharacterDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dndChar_repository.db");
        }
    }
}