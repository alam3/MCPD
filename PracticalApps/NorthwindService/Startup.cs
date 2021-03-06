using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
// Creating a web service for the Northwind Database
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Packt.Shared;
using static System.Console;
// Example differentiating between MVC and WebAPI Controllers using routes
using NorthwindService.Repositories;
// Imports for adding Sawgger UI (needs Microsoft.OpenApi.Models above)
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
// Endpoint routing configuration
using Microsoft.AspNetCore.Http; // For GetEndpoint() extension method
using Microsoft.AspNetCore.Routing; // RouteEndpoint


namespace NorthwindService
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
            // Enable Cross-Origin Resource Sharing (CORS)
            services.AddCors();

            // Configuring the Northwind data context
            string databasePath = Path.Combine("..", "Northwind.db");
            services.AddDbContext<Northwind>(options => options.UseSqlite($"Data Source={databasePath}"));

            // show supported media types of default output formatters, add XML serializer formatters, and set
            // compatibility to ASP.NET Core 3.0
            services.AddControllers(options => {
                WriteLine("Default output formatters:");
                foreach(IOutputFormatter formatter in options.OutputFormatters) {
                    var mediaFormatter = formatter as OutputFormatter;
                    if (mediaFormatter == null) {
                        WriteLine($" {formatter.GetType().Name}");
                    } else { // OutputFormatter class has SupportedMediaTypes
                        WriteLine(" {0}, Media types: {1}",
                            arg0: mediaFormatter.GetType().Name,
                            arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
                    }
                }
            }).AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "NorthwindService", Version = "v1" });
            // });

            // Register the CustomerRepository for use at runtime
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Register the Swagger generator and define a Swagger document for Northwind Service
            services.AddSwaggerGen(options => {
                options.SwaggerDoc(name: "v1", info: new OpenApiInfo {
                    Title = "Northwind Service API", Version = "v1"
                });
            });

            // Add health checks from the references package ...HealthChecks.EntityFrameworkCore in NorthwindService.csproj
            services.AddHealthChecks().AddDbContextCheck<Northwind>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind Service API Version 1");
                    c.SupportedSubmitMethods(new[] {
                        SubmitMethod.Get, SubmitMethod.Post,
                        SubmitMethod.Put, SubmitMethod.Delete });
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Add CORS Support. Must be after UseRouting() and before UseEndpoints().
            app.UseCors(configurePolicy: options => {
                options.WithMethods("GET", "POST", "PUT", "DELETE");
                options.WithOrigins("https://localhost:5002"); // for MVC client
            });

            // Use basic health checks
            app.UseHealthChecks(path: "/howdoyoufeel");

            // Lambda statement to output information about the selected endpoint during every request
            app.Use(next => (context) => {
                var endpoint = context.GetEndpoint();
                if (endpoint != null) {
                    WriteLine("*** Name: {0}; Route: {1}; Metadata: {2}",
                              arg0: endpoint.DisplayName,
                              arg1: (endpoint as RouteEndpoint)?.RoutePattern,
                              arg2: string.Join(", ", endpoint.Metadata));
                }

                // pass context to the next middleware in the pipeline
                return next(context);
            });

            // Register the middleware adding more HTTP security headers
            app.UseMiddleware<SecurityHeaders>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .AllowAnonymous(); // improvement in .NET5 enabling anonymous HTTP calls when using endpoint routing.
            });
        }
    }
}
