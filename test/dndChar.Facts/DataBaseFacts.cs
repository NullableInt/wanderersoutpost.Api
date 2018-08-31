using System;
using System.Linq;
using dndChar.Character;
using dndChar.Character.AbilityScores;
using dndChar.Database;
using DbUp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace dndChar.Facts
{
    public class DataBaseFacts : IDisposable
    {
        private readonly ServiceCollection _services;

        public DataBaseFacts()
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = configBuilder.Build();

            var connectionString = Configuration["Data:ApplicationDb:ConnectionString"];

            _services = new ServiceCollection();
            _services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite(connectionString));
            _services.AddTransient<ApplicationDbContext>();
            using (var dbContext = DbContext)
            {
                dbContext.Database.EnsureCreated();
            }
        }

        public IConfigurationRoot Configuration { get; set; }

        private ApplicationDbContext DbContext => _services.BuildServiceProvider().GetService<ApplicationDbContext>();


        [Fact]
        public void CreatePlayer()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(Configuration["Data:ApplicationDb:ConnectionString"]);

            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using (dbContext)
            {
                var playerId = Guid.NewGuid();
                var player = new Player
                {
                    CharacterSheet = new CharacterSheet(),
                    DisplayName = "TestMan",
                    Email = "Test@TestMail.se",
                    PlayerId = playerId
                };

                DbContext.Players.Add(player);
                var all = DbContext.Players.ToList();
                DbContext.SaveChanges();

                var retrievedPlayer = DbContext.Players.Single(p => p.PlayerId == playerId);

                Assert.NotNull(retrievedPlayer);
            }
        }

        public void Dispose()
        {
            using (var dbContext = DbContext)
            {
                dbContext.Database?.EnsureDeleted();
            }
        }
    }
}