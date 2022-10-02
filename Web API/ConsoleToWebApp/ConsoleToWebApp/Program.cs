using System;

namespace ConsoleToWebApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => 
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
