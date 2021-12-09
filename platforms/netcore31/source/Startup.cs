using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NetWebAppSample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(Web.GetStandardHtml("<h1>.NET web app sample</h1><p>If you are seeing this, yay, the web app works!</p><h2>Available tools</h2><dl><dt><a href=\"/GetConnection\">GetConnection</a></dt><dd>Gets info about the connection between a client and the web app and about a client request (as perceived by this web app). No parameters expected.</dd><dt><a href=\"/GetEnvironment\">GetEnvironment</a></dt><dd>Gets info about the environment in which the web app is running. No parameters expected.</dd><dt><a href=\"/GetFileSystemEntries\">GetFileSystemEntries</a></dt><dd>Gets info about the filesystem entries the web app can access. No parameters expected.</dd><dt><a href=\"/GetTime\">GetTime</a></dt><dd>Gets the current date and time in the web app environment. No parameters expected.</dd><dt><a href=\"/TestPing\">TestPing</a></dt><dd>Tests if a network ping can be successfully completed by the web app. Expected parameter is \"host\".</dd><dt><a href=\"/TestSQLServerConnection\">TestSQLServerConnection</a></dt><dd>Tests if a SQL Server connection can be successfully opened by the web app. Expected parameter is \"connectionString\".</dd><dt><a href=\"/TestTCPPort\">TestTCPPort</a></dt><dd>Tests if a TCP port can be successfully opened by the web app. Expected parameters are \"host\" and \"port\".</dd></dl>"));
                });

                endpoints.MapGet("/GetConnection", async context => await Commands.GetConnection.Execute(context));
                endpoints.MapGet("/GetEnvironment", async context => await Commands.GetEnvironment.Execute(context));
                endpoints.MapGet("/GetFileSystemEntries", async context => await Commands.GetFileSystemEntries.Execute(context));
                endpoints.MapGet("/GetTime", async context => await Commands.GetTime.Execute(context));
                endpoints.MapGet("/TestPing", async context => await Commands.TestPing.Execute(context));
                endpoints.MapGet("/TestSQLServerConnection", async context => await Commands.TestSQLServerConnection.Execute(context));
                endpoints.MapGet("/TestTCPPort", async context => await Commands.TestTCPPort.Execute(context));
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
        }
    }
}