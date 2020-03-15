using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Source.net.api.Utils;
using System.Text;
using Source.net.api.Security;
using Source.net.services.Mappers;
using Source.net.services.Database;
using Source.net.services.Services.Implementations;
using Source.net.services.Repositories.Interfaces;
using Source.net.services.Repositories.Implementations;
using Source.net.services.Services.Interfaces;
using Source.net.api.Filters;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Source.net.api.Utils.HttpContext;

namespace Source.net.api
{
    public class Startup
    {
        public class BasicAuthDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
            {
                var securityRequirements = new Dictionary<string, IEnumerable<string>>(){
                    {
                        "Bearer",
                        new string[] { }
                    }  
                };

                swaggerDoc.Security = new[] { securityRequirements };
            }
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
               /// x => x.Filters.Add<ErrorFilter>()
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SourceNetContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Services
            services.AddScoped<AuthenticationService, JWTAuthenticationService>();
            services.AddScoped<CategoryService, CategoryServiceImp>();
            services.AddScoped<UserService, UserServiceImp>();
            services.AddScoped<PostService, PostServiceImp>();
            services.AddScoped<TagService, TagServiceImp>();
            services.AddScoped<RatingService, RatingServiceImp>();

            // Repositories
            services.AddScoped<UserRepository, SqlServerUserRepository>();
            services.AddScoped<CategoryRepository, SqlServerCategoryRepository>();
            services.AddScoped<PostRepository, SqlServerPostRepository>();
            services.AddScoped<TagRepository, SqlServerTagRepository>();
            services.AddScoped<PostTagRepository, SqlServerPostTagRepository>();
            services.AddScoped<Statistics, DashboardStatistics>();
            services.AddScoped<RatingRepository, SqlServerRatingRepository>();

            // Mappers
            services.AddSingleton<UserMapper>();
            services.AddSingleton<CategoryMapper>();
            services.AddSingleton<RoleMapper>();
            services.AddSingleton<PostMapper>();
            services.AddSingleton<TagMapper>();
            services.AddSingleton<RatingMapper>();


            // Utils
            services.AddScoped<HttpContextExtensible, HttpContextExtension>();

            var contact = Configuration.GetSection("Swagger").GetSection("Contact");
            var license = Configuration.GetSection("Swagger").GetSection("License");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "Source.net api",
                    Version = "v1",
                    Contact = new Contact {
                        Email = contact.GetSection("Email").Value,
                        Name = contact.GetSection("Name").Value,
                        Url = contact.GetSection("Url").Value
                    },
                    Description = "Api to use multiuser blog system",
                    License = new License {
                        Name = license.GetSection("Name").Value,
                        Url = license.GetSection("Url").Value
                    }
                });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Source net API v1.0");
                });
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
