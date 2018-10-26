using System;

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
            var dbType = Configuration.GetSection("Data:DbType").Value;
            var selectedDbType = Enum.Parse<DatabaseProviders>(dbType, true);
            var connectionString = Configuration.GetConnectionString(selectedDbType.ToString());
            if (string.IsNullOrEmpty(connectionString))
                connectionString = Configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            switch (selectedDbType)
            {
                case DatabaseProviders.Sqlite:
                    optionsBuilder.UseSqlite(connectionString);
                    break;
                case DatabaseProviders.SqlServer:
                    optionsBuilder.UseSqlServer(connectionString);
                    break;
                default:
                    throw new NotImplementedException($"{selectedDbType} is not a supported database.");
            }

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}