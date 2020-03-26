using System;
using System.Text;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ParameterAPIService.Data;
using ParameterAPIService.Helpers;
using ParameterAPIService.Interfaces;
using ParameterAPIService.Services;

namespace ParameterService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string ConnectionName { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var connectionStrings = string.Empty;
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            if (appSettings.ISTEST.Equals("Y"))
            {
                if (appSettings.UseLocalDB == "Y")
                {
                    ConnectionName = Configuration.GetValue<string>("ConnectionStrings:Development:SQLLocalConnection");
                    AS400Singleton.AS400.ConnectionString = Configuration.GetValue<string>("ConnectionStrings:Development:AS400Connection")
                        .Replace($"[{ nameof(AppSettings.AS400_USERID) }]", Cryptography.DecryptString(appSettings.AS400_USERID))
                        .Replace($"[{ nameof(AppSettings.AS400_PASSWD) }]", Cryptography.DecryptString(appSettings.AS400_PASSWD));
                }
                else
                {
                    connectionStrings = Configuration.GetValue<string>("ConnectionStrings:Development:SQLConnection");
                    ConnectionName = connectionStrings
                        .Replace($"[{ nameof(AppSettings.SQL_USERID) }]", Cryptography.DecryptString(appSettings.SQL_USERID))
                        .Replace($"[{ nameof(AppSettings.SQL_PASSWD) }]", Cryptography.DecryptString(appSettings.SQL_PASSWD));
                    AS400Singleton.AS400.ConnectionString = Configuration.GetValue<string>("ConnectionStrings:Development:AS400Connection")
                        .Replace($"[{ nameof(AppSettings.AS400_USERID) }]", Cryptography.DecryptString(appSettings.AS400_USERID))
                        .Replace($"[{ nameof(AppSettings.AS400_PASSWD) }]", Cryptography.DecryptString(appSettings.AS400_PASSWD));
                }
            }
            else
            {
                connectionStrings = Configuration.GetValue<string>("ConnectionStrings:Production:SQLConnection");
                ConnectionName = connectionStrings
                    .Replace($"[{ nameof(AppSettings.SQL_USERID) }]", Cryptography.DecryptString(appSettings.SQL_USERID))
                    .Replace($"[{ nameof(AppSettings.SQL_PASSWD) }]", Cryptography.DecryptString(appSettings.SQL_PASSWD));
                AS400Singleton.AS400.ConnectionString = Configuration.GetValue<string>("ConnectionStrings:Production:AS400Connection")
                    .Replace($"[{ nameof(AppSettings.AS400_USERID) }]", Cryptography.DecryptString(appSettings.AS400_USERID))
                    .Replace($"[{ nameof(AppSettings.AS400_PASSWD) }]", Cryptography.DecryptString(appSettings.AS400_PASSWD));
            }

            services.AddDbContext<ApplicationSQLContext>(options => options.UseSqlServer(ConnectionName));

            var key = Encoding.ASCII.GetBytes(appSettings.SECRET);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LHB Parameter Service API",
                    Version = "v1",
                    Description = "Core Bank Parameter resources.",
                    TermsOfService = new Uri("https://www.lhbank.co.th"),
                    Contact = new OpenApiContact
                    {
                        Name = "Deposit Department",
                        Email = "DepositDepartmentUnit@lhbank.co.th"
                    },
                    License = new OpenApiLicense
                    {
                        Name = $"Copyright© {DateTime.Now.Year} LAND AND HOUSES BANK PUBLIC COMPANY LIMITED",
                        Url = new Uri("https://www.lhbank.co.th")
                    }
                });
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
            });

            // Register Custom Service
            services.AddScoped(typeof(IParameterServices), typeof(ParameterServices));

            services.AddLogging();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(configs =>
            {
                configs.SwaggerEndpoint("/swagger/v1/swagger.json", "LHB Parameter Service API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
