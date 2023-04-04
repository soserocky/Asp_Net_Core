using Microsoft.Extensions.DependencyInjection;

namespace ConsoleToWebApp
{
    internal class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async context => {
                await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            });
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello, World. This is a web application.");
                });
            });
        }

        internal void ConfigureServices(IServiceCollection services)
        {

        }
    }
}