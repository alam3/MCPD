// Building the simplest possible ASP.NET Core website project

using Microsoft.AspNetCore.Hosting; // for IWebHostBuilder.Configure
using Microsoft.AspNetCore.Builder; // for IApplicationBuilder.Run
using Microsoft.AspNetCore.Http; // for HttpResponse.WriteAsync
using Microsoft.Extensions.Hosting; // for Host

Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => {
    webBuilder.Configure(app => {
        app.Run(context => context.Response.WriteAsync("Hello World Wide Web!"));
    });
}).Build().Run();