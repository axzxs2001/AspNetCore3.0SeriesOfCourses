using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAndAuthorizationCookio.Permission;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthenticationAndAuthorizationCookio
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
            services.AddControllersWithViews(opt =>
            {
                opt.EnableEndpointRouting = false;
            });

            services.AddAuthorization(opt =>
            {
                var userPerssions = new List<UserPermission> {
                     new UserPermission{  Url="/home/index",UserName="gsw"},
                     new UserPermission{  Url="/",UserName="gsw"},
                     new UserPermission{  Url="/home/privacy",UserName="gsw"},
                };
                opt.AddPolicy("Permission", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("/denied", userPerssions));
                });
            })
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = new PathString("/login");
                    opt.AccessDeniedPath = new PathString("/denied");
                });

            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            //¹Ì¶¨½ÇÉ«
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(opt =>
            //    {
            //        opt.LoginPath = new PathString("/login");
            //        opt.AccessDeniedPath = new PathString("/denied");
            //    });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvcWithDefaultRoute();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");

            //});
        }
    }
}
