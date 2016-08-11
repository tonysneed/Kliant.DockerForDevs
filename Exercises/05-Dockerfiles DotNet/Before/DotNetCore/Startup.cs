using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HelloWeb
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Hello ASP.NET Core on {env.EnvironmentName}!");
            });
        }
    }
}
