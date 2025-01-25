using StarWarsAPI.Services;

namespace StarWarsAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<PlanetService>();
            builder.Services.AddScoped<PeopleService>();

            builder.Services.AddRazorPages();

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
