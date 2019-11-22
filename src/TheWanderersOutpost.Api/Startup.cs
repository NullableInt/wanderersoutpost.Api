using TheWanderersOutpost.Api.Database;
using TheWanderersOutpost.Api.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization;
using TheWanderersOutpost.Api.Models;
using System;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TheWanderersOutpost.Api
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
            services
                .AddMvc()
                .AddJsonOptions(op =>
                {
                    op.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    op.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    op.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddResponseCompression();

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

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            foreach (Type type in Assembly.GetAssembly(typeof(BaseCharacterSheet)).GetTypes()
                                    .Where(d => d.IsClass && d.IsSubclassOf(typeof(BaseCharacterSheet))))
            {
                services.AddSingleton(typeof(ICharacterSheet), type);
                BsonClassMap.LookupClassMap(type);
            }

            SetupAuth0(services);

            services.AddOpenApiDocument(settings => {
                settings.SchemaType = NJsonSchema.SchemaType.OpenApi3;
                settings.OperationProcessors.Insert(settings.OperationProcessors.Count, new OperationAnonymiserProcessor());
            });
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

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            
            AddCamelCaseConvention();

            app.UseAuthentication();

            app.UseCors(builder => builder
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins(Configuration.GetSection("AllowedCors").Get<AllowedCors>().Cors)
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseMvc();
            app.UseOpenApi();
        }

        private static void AddCamelCaseConvention()
        {
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention()
            };

            ConventionRegistry.Register(new CamelCaseElementNameConvention().Name, pack, t => true);
        }
    }
}
