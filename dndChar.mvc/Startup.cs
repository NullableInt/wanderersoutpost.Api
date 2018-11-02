using System;
using dndChar.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dndChar.mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ConfigureDatabase(services);

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });   
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            var dbType = Configuration.GetSection("Data:DbType").Value;
            var selectedDbType = Enum.Parse<DatabaseProviders>(dbType, true);
            var connectionString = Configuration.GetConnectionString(selectedDbType.ToString());
            if (string.IsNullOrEmpty(connectionString))
                connectionString = Configuration.GetConnectionString("DefaultConnection");

            switch (selectedDbType)
            {
                case DatabaseProviders.Sqlite:
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
                    break;
                case DatabaseProviders.SqlServer:
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
                    break;
                default:
                    throw new NotImplementedException($"{selectedDbType} is not a supported database.");
            }

            var dbContext = services.BuildServiceProvider().GetService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();
        }
    }
}
