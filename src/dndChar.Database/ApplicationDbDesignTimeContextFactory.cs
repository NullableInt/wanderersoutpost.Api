using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace dndChar.Database
{
    public class ApplicationDbDesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public ApplicationDbDesignTimeContextFactory()
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = configBuilder.Build();
        }

        public ApplicationDbDesignTimeContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = Configuration["Data:ApplicationDb:ConnectionString"];

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}