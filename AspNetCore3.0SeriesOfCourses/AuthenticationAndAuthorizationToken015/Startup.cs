using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAndAuthorizationToken015.Permission;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAndAuthorizationToken015
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
     

            var audience = Configuration.GetSection("Audience")["Audience"];
            var secret = Configuration.GetSection("Audience")["Secret"];
            var issuer = Configuration.GetSection("Audience")["Issuer"];
            //∂‘≥∆º”√‹
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            //«© ∆æ÷§
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var userPerssions = new List<UserPermission> {
                     new UserPermission{  Url="/weatherforecast",Name="admin"}                   
                };
            var permissionRequirement = new PermissionRequirement("/denied", userPerssions, ClaimTypes.Role, issuer, audience, signingCredentials, TimeSpan.FromSeconds(1000));

            services.AddAuthorization(opt =>
            {

                opt.AddPolicy("Permission", policy =>
                {
                    policy.Requirements.Add(permissionRequirement);
                });
            })
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true
                    };
                });

            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton(permissionRequirement);

            services.AddControllers(opt =>
            {
                opt.EnableEndpointRouting = false;
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
