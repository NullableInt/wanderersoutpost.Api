
using dndChar.Api.Util;
using dndChar.Database;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using dndCharApi.Models.RpgChar;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace dndCharApi
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
            services.AddMvc(options =>
                                options.Conventions.Add(new ApiExplorerVisibilityEnabledConvention()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<DocumentStoreHolder>();

            services.Configure<MongoConfig>(Configuration.GetSection("MongoConfig"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                        .WithOrigins("http://localhost:3000", "http://localhost:8080")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            SetupAuth0(services);
        }

        private void SetupAuth0(IServiceCollection services)
        {
            string domain = $"https://{Configuration["Auth0:Domain"]}";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Authority"];
                options.Audience = Configuration["Auth0:Audience"];
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidAudience = Configuration["Auth0:Audience"],
                    ValidIssuer = domain
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
            });

            // register the scope authorization handler
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());

            ConventionRegistry.Register(new CamelCaseElementNameConvention().Name,pack,t => true);

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseCors(builder => builder
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins(Configuration.GetSection("AllowedCors").Get<AllowedCors>().Cors)
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
