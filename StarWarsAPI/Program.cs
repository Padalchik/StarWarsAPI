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

            /*
            // Получаем экземпляр PlanetService через DI
            using (var scope = app.Services.CreateScope())
            {
                var planetService = scope.ServiceProvider.GetRequiredService<PlanetService>();
                var planet = await planetService.GetPlanet(1);

                Console.WriteLine($"Planet Name: {planet?.Name}");
            }
            */

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
