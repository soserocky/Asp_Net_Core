using System;

namespace ConsoleToWebApp 
{
    internal class Program
    {
        //Every Asp.NET Core Web Application starts as a Console Application and looks for a method called "Main"
        //In the "Main" method, we can spin up a Host using the HostBuilder class and configure the "defaults" 
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
