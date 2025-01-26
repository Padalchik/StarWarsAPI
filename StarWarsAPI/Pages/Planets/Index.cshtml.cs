using Microsoft.AspNetCore.Mvc.RazorPages;
using StarWarsAPI.Services;
using StarWarsAPI.ViewModels;

namespace StarWarsAPI.Pages.Planets
{
    public class IndexModel : PageModel
    {
        private readonly ISwapiService _swapiService;

        public IndexModel(ISwapiService swapiService)
        {
            _swapiService = swapiService;
        }

        public PlanetViewModel Planet { get; set; }

        public async Task OnGetAsync(int planetIndex = 1)
        {
            var (planet, people) =  await _swapiService.GetPlanetsWithPeople(planetIndex);
            Planet = new PlanetViewModel(planet.Id, planet.Name, planet.Gravity,
                people.Select(p => new PersonViewModel(p.Name)).ToList());
        }
    }
}
