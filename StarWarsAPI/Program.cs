using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using StarWarsAPI.Services;

namespace StarWarsAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ISwapiClient, SwapiClient>();
            builder.Services.AddScoped<ISwapiService, SwapiService>();

            builder.Services.AddRazorPages();

            var configuration = builder.Configuration;
            builder.Services.Configure<SwapiSettings>(configuration.GetSection("Swapi"));
            builder.Services.AddOptions<SwapiSettings>().ValidateDataAnnotations();

            builder.Services.AddHttpClient<ISwapiClient, SwapiClient>((services, client) =>
            {
                var settings = services.GetRequiredService<IOptions<SwapiSettings>>().Value;
                client.BaseAddress = new Uri(settings.ApiUrl);
            });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/Planets");
                return Task.CompletedTask;
            });

            app.Run();
        }
    }
}
