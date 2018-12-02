using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using DutchApp.Models;
using Microsoft.EntityFrameworkCore;
using DutchApp.Data;
using DutchApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DutchApp
{
    public class Startup
    {
      private readonly IConfiguration _config;

      public Startup(IConfiguration config)
      {
        _config = config;
      }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });


        services.AddIdentity<AppUser, IdentityRole>(cfg =>
        {
            cfg.User.RequireUniqueEmail = true;
            cfg.Password.RequireUppercase = false;
        })
            .AddEntityFrameworkStores<DutchContext>();
        

        services.AddDbContext<DutchContext>(options =>
        { 
          options.UseNpgsql(_config.GetConnectionString("DutchConnectionString"));
        });


        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            {
              HotModuleReplacement = true,
              ConfigFile = "webpack.netcore.config.js",
              HotModuleReplacementClientOptions = new Dictionary<string, string>{
            {"reload", "true"}
          }
        });
      }
            else
            {
                app.UseExceptionHandler("/App/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCookiePolicy();

            app.UseStaticFiles();
            
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
              routes.MapRoute(
                  name: "default",
                  template: "{controller=App}/{action=Index}/{id?}");

              routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "App", action = "Index" });
            });
    }
    }
}
