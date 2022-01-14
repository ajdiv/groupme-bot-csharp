using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace GroupmeBot.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
                    webBuilder.UseStartup<Startup>()
                    .UseUrls("http://*:" + port);
                    // Uncomment the following when debugging using docker
                    // Heroku requires http to be exposed (not https) as it handles it internally
                    //.UseUrls("https://*:" + port); ;
                });
    }
}
