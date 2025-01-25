using Microsoft.AspNetCore.Mvc.RazorPages;
using StarWarsAPI.Services;
using StarWarsAPI.ViewModels;

namespace StarWarsAPI.Pages.Planets
{
    public class IndexModel : PageModel
    {
        private readonly PlanetService _planetService;
        private readonly PeopleService _peopleService;

        public IndexModel(PlanetService planetService, PeopleService peopleService)
        {
            _planetService = planetService;
            _peopleService = peopleService;
        }

        public PlanetViewModel Planet { get; set; }

        public async Task OnGetAsync(int planetIndex = 1)
        {
            var planetDTO = await _planetService.GetPlanet(planetIndex);
            Planet = await _planetService.GetPlanetViewModel(planetDTO);
            Planet.Id = planetIndex;
        }
    }
}
