using StarWarsAPI.DTO;
using StarWarsAPI.ViewModels;

namespace StarWarsAPI.Services
{
    public class PlanetService
    {
        private readonly PeopleService _peopleService;

        public PlanetService(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public async Task<PlanetDTO> GetPlanet(int planetIndex)
        {
            string apiUrl = $"https://swapi.dev/api/planets/{planetIndex}/";

            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var planetDTO = await response.Content.ReadFromJsonAsync<PlanetDTO>();

            return planetDTO;
        }

        public async Task<PlanetViewModel> GetPlanetViewModel(PlanetDTO planetDTO)
        {
            var planetViewModel = new PlanetViewModel();

            planetViewModel = new PlanetViewModel()
            {
                Name = planetDTO.Name,
                Gravity = planetDTO.Gravity,
            };

            foreach (var residentLink in planetDTO.Residents)
            {
                PeopleDTO peopleDTO = await _peopleService.GetPeople(residentLink);
                PeopleViewModel peopleViewModel = new PeopleViewModel()
                {
                    Name = peopleDTO.Name,
                };

                planetViewModel.AddResidence(peopleViewModel);
            }

            return planetViewModel;
        }
    }
}
