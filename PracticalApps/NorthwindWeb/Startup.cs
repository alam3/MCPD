using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// For using EntityFrameworkCore with ASP.NET
using System.IO;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
// Configuring the HTTP request pipeline
using Microsoft.AspNetCore.Routing;
using static System.Console;

namespace NorthwindWeb
{
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            // Enable use of Razor Pages, which are found in the "Pages" directory with ".cshtml" extension
            // Even tho use of default static files is defined, the webserver will pick up Razor Pages first
            services.AddRazorPages();
            
            // For using EntityFrameworkCore with ASP.NET
            // Registers the Northwind database context class to use SQLite as its db provider
            string databasePath = Path.Combine("..", "Northwind.db");
            services.AddDbContext<Northwind>(options => options.UseSqlite($"Data source={databasePath}"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            app.UseRouting(); // must be used with a call to UseEndpoints()

            // Configuring the HTTP request pipeline - use an anonymous method as a middleware delegate
            // Handles the pipeline AFTER UseRouting() is called and shows which endpoint was chosen and
            // handles the '/bonjour' route outside of the UseRouting()/UseEndpoints() calls.
            // Going to '/bonjour' will not display data on the console as it is processed after the UseRouting return data
            app.Use(async (HttpContext context, Func<Task> next) => {
                var rep = context.GetEndpoint() as RouteEndpoint;
                if (rep != null) {
                    WriteLine($"Endpoint name: {rep.DisplayName}");
                    WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
                }
                if (context.Request.Path == "/bonjour") {
                    // in the case of a match on URL path, this becomes a terminating
                    // delegate that returns so does not call the next delegate
                    await context.Response.WriteAsync("Bonjour Monde!");
                    return;
                }
                // we could modify the request before calling the next delegate
                await next();
                // we could modify the response after calling the next delegate
            });


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
