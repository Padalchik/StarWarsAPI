using StarWarsAPI.DTO;

namespace StarWarsAPI.Services
{
    public class PeopleService
    {
        public async Task<PeopleDTO> GetPeople(int peopleIndex)
        {
            string apiUrl = $"https://swapi.dev/api/people/{peopleIndex}/";

            return await GetPeople(apiUrl);
        }

        public async Task<PeopleDTO> GetPeople(string apiUrl)
        {
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var peopleDTO = await response.Content.ReadFromJsonAsync<PeopleDTO>();

            return peopleDTO;
        }
    }
}
