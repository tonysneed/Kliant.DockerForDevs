using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DockerComposeDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get environment variables
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables("");

            var config = builder.Build();

            var url = config["ASPNETCORE_URLS"] ?? "http://*:5000";
            var env = config["ASPNETCORE_ENVIRONMENT"] ?? "Development";
            
            var host = new WebHostBuilder()
                        .UseKestrel()
                        .UseUrls(url)
                        .UseEnvironment(env)
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .Build();
            host.Run();
        }
    }
}