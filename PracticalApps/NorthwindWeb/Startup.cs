using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NorthwindWeb
{
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            // Enable use of Razor Pages, which are found in the "Pages" directory with ".cshtml" extension
            // Even tho use of default static files is defined, the webserver will pick up Razor Pages first
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            // Tell the webserver to use and find the static files to present when the website is accessed.
            app.UseDefaultFiles(); // index.html, default.html, and so on
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                // Statement directing to use the Razor Pages
                endpoints.MapRazorPages();

                // endpoints.MapGet("/", async context =>
                endpoints.MapGet("/hello", async context => // Tell the webserver to only do this on the /hello endpoint
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
