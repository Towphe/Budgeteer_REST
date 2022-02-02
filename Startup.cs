using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgeteer_REST.Identity;

namespace Budgeteer_REST
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityCore<AppUser>(opts =>
            {
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppUserDbContext>().AddSignInManager().AddDefaultTokenProviders();
            services.AddAuthentication(opts => opts.DefaultScheme = IdentityConstants.ApplicationScheme).AddCookie(IdentityConstants.ApplicationScheme, opts =>
            {
                // Add authentication redirects here
            });
            services.AddDbContext<AppUserDbContext>(opts =>
            {
                opts.UseNpgsql(Configuration["AppUserDB:Key"]);
            });
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("NotFound", "Home");
            });
        }
    }
}
