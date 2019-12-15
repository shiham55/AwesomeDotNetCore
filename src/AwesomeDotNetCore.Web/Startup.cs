using AwesomeDotNetCore.Data;
using AwesomeDotNetCore.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AwesomeDotNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // adds services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            services.Configure<CookiePolicyOptions>(options => { options.CheckConsentNeeded = context => true; options.MinimumSameSitePolicy = SameSiteMode.None; });

            services.AddDbContext<AdventureWorks2017Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:AdventureWorksConnection"]));

            services.AddDefaultIdentity<ApplicationUser>().AddRoles<ApplicationUserRole>().AddEntityFrameworkStores<AdventureWorks2017Context>();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews();

            services.AddRazorPages();

            //services.AddApplicationInsightsTelemetry();
        }

        // configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment() || Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT").Equals("Development"))
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
