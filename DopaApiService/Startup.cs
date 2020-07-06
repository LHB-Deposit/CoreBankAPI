using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DopaApiService.Helpers;
using DopaApiService.Interfaces;
using DopaApiService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace DopaApiService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var connectionStrings = string.Empty;
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            if (appSettings.ISTEST.Equals("Y"))
            {
            //    connectionStrings = Configuration.GetValue<string>("ConnectionStrings:Development:SQLConnection")
            //        .Replace($"[{ nameof(AppSettings.SQL_USERID) }]", Cryptography.DecryptString(appSettings.SQL_USERID))
            //        .Replace($"[{ nameof(AppSettings.SQL_PASSWD) }]", Cryptography.DecryptString(appSettings.SQL_PASSWD));
            //}
            //else
            //{
            //    connectionStrings = Configuration.GetValue<string>("ConnectionStrings:Production:SQLConnection")
            //        .Replace($"[{ nameof(AppSettings.SQL_USERID) }]", Cryptography.DecryptString(appSettings.SQL_USERID))
            //        .Replace($"[{ nameof(AppSettings.SQL_PASSWD) }]", Cryptography.DecryptString(appSettings.SQL_PASSWD));
            }

            //services.AddDbContext<ApplicationSQLContext>(options => options.UseSqlServer(ConnectionName));

            // configure jwt authentication
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
                    Title = "LHB DOPA API Service",
                    Version = "v1",
                    Description = "Check Card status.",
                    TermsOfService = new Uri("https://www.lhbank.co.th"),
                    Contact = new OpenApiContact
                    {
                        Name = "Deposit Department",
                        Email = "DepositDepartmentUnit@lhbank.co.th"
                    },
                    License = new OpenApiLicense
                    {
                        Name = $"Copyright{DateTime.Now.Year} LAND AND HOUSES BANK PUBLIC COMPANY LIMITED",
                        Url = new Uri("https://www.lhbank.co.th")
                    }
                });
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
            });
            services.AddScoped(typeof(IApiService), typeof(ApiService));
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
                configs.SwaggerEndpoint("/swagger/v1/swagger.json", "LHB Dopa API Service V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
