using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wanyar.Core.Convertors;
using Wanyar.Core.Services;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Context;

namespace WanyarCms
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddMvc();           
          

            #region Context
            services.AddDbContext<WanyarContext>(option =>
            {
                option.UseSqlServer("Data Source=.;Initial Catalog=Yazdanpanah_LibraryDb;Integrated Security=true;TrustServerCertificate=True;MultipleActiveResultSets=true;");
            });
            #endregion

            #region Ioc
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IArticleGroupService, ArticleGroupService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IPermisionService, PermisionService>();
            #endregion

            #region Identity
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme=CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme=CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme=CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath="/Login";
                options.LogoutPath="/LogOut";
                options.ExpireTimeSpan=TimeSpan.FromMinutes(43200);
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
