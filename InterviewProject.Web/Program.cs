using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace InterviewProject
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
                    webBuilder.UseStartup<Startup>();

                    var port = Environment.GetEnvironmentVariable("PORT");
                    if (!string.IsNullOrWhiteSpace(port))
                    {
                        webBuilder.UseUrls("http://*:" + port);
                    }
                });
    }
}
