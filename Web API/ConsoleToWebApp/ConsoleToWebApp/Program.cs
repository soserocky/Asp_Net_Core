using System;

namespace ConsoleToWebApp 
{
    internal class Program
    {
        //Every Asp.NET Core Web Application starts as a Console Application and looks for a method called "Main"
        //In the "Main" method, we can spin up a Host using the HostBuilder class and configure the "defaults" 
        static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);
            //Creates a generic host builder. Has no idea about the app being "web"

            hostBuilder.ConfigureWebHostDefaults(ConfigureWebHostDefaults); 
            //The exact above line of code actually transforms and configures the App to become a "web" app.
            
            IHost host = hostBuilder.Build();
            //The above line of code creates the host based on the configurations as in the earlier lines of code. 

            host.Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args);
        }

        internal static void ConfigureWebHostDefaults(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }

        //Short cut method of writing the above
        //static void Main(string[] args) 
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //private static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>();
        //    });
    }
}
