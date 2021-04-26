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
using Microsoft.OpenApi.Models;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

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

      services.AddControllers();

      services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

      foreach (Type type in Assembly.GetAssembly(typeof(BaseCharacterSheet)).GetTypes()
                              .Where(d => d.IsClass && d.IsSubclassOf(typeof(BaseCharacterSheet))))
      {
        services.AddSingleton(typeof(ICharacterSheet), type);
        BsonClassMap.LookupClassMap(type);
      }

      SetupAuth0(services);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Some API", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath, true);
        c.GeneratePolymorphicSchemas();
        c.DescribeAllParametersInCamelCase();
        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
          Type = SecuritySchemeType.OAuth2,
          Flows = new OpenApiOAuthFlows
          {
            Implicit = new OpenApiOAuthFlow
            {
              AuthorizationUrl = new Uri($"https://{Configuration["Auth0:Domain"]}", UriKind.RelativeOrAbsolute),
              Scopes = new Dictionary<string, string>
                      {
                                { "readAccess", "Access read operations" },
                                { "writeAccess", "Access write operations" }
                      }
            }
          }
        });
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

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger(c =>
      {
        c.RouteTemplate = "api-docs/{documentName}/swagger.json";
      })
      .UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Plz read this boyo man");
        c.DocumentTitle = "Mmmyyyea bby";
        c.RoutePrefix = "api-docs";
        c.EnableDeepLinking();
        c.DefaultModelExpandDepth(3);
        c.DefaultModelRendering(ModelRendering.Model);
        c.DocExpansion(DocExpansion.None);
      });

      app.UseDeveloperExceptionPage();

      AddCamelCaseConvention();

      app.UseAuthentication();
      
      app.UseCors(builder => builder
          .SetIsOriginAllowedToAllowWildcardSubdomains()
          .WithOrigins(Configuration.GetSection("AllowedCors").Get<AllowedCors>().Cors)
          .AllowCredentials()
          .AllowAnyHeader()
          .AllowAnyMethod());

      app.UseRouting().UseAuthorization().UseEndpoints(e =>
      {
        e.MapControllers();
      });
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
