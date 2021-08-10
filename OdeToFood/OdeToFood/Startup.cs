using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood
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
            services.AddRazorPages();
            services.AddControllers();

            services.AddDbContextPool<OdeToFoodDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            });

            services.AddScoped<IRestaurantData, SqlRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // Only in production because of caching issues is the HSTS Middleware.
                // HSTS Middleware essentially instructs the browser to only access this information over a secure connection.
                // If for some reason you don't want to use a secure HTTPS connection, perhaps because you have a proxy sitting in front that 
                // takes car of the encryption for you, then you can remove the HSTS Middleware, as well as the HTTPS Redirect Middleware.
                // This is going to send an HTTP redirect instruction to any browser that tries to access the application using plain HTTP.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Static Files attempts to serve a request by responding with a file that's in the wwwroot folder, 
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // This is a piece of middleware that's going to help track if the user has consented to the use of cookies.
            // Once the user accepts your cookie policy, there's going to be a cookie set for this application, the AspNet.Consent cookie that will let
            // you know, if the user ever returns here, that the user has already consented.
            // So this works with some other services inside of ASP.NET Core that you can check with to make sure the user has consented to the use of 
            // cookies and tracking. 
            //app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
