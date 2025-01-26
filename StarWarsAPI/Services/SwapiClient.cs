using Microsoft.Extensions.Options;
using StarWarsAPI.DTO;
using StarWarsAPI.Models;

namespace StarWarsAPI.Services;

public interface ISwapiClient
{
    Task<Planet> GetPlanet(int planetIndex);
    Task<Person> GetPerson(Uri apiUrl);
    Task<Person> GetPerson(int peopleIndex);
}

public class SwapiClient : ISwapiClient
{
    private HttpClient _httpClient;
    private SwapiSettings _settings;

    public SwapiClient(HttpClient httpClient, IOptions<SwapiSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
    }

    public async Task<Planet> GetPlanet(int planetIndex)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"planets/{planetIndex}/");
        response.EnsureSuccessStatusCode();

        var planetDto = await response.Content.ReadFromJsonAsync<PlanetDTO>();
        if (planetDto == null)
        {
            throw new NullReferenceException("can't parse json");
        }

        var planet = new Planet(planetIndex, planetDto.Name, planetDto.Gravity, planetDto.Residents);
        return planet;
    }

    public async Task<Person> GetPerson(Uri apiUrl)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();

        var personDto = await response.Content.ReadFromJsonAsync<PersonDTO>();
        if (personDto == null)
        {
            throw new NullReferenceException("can't parse json");
        }

        var person = new Person(personDto.Name);
        return person;
    }

    public async Task<Person> GetPerson(int peopleIndex = 1)
    {
        var apiUrl = new Uri($"{_settings.ApiUrl}/people/{peopleIndex}/");
        return await GetPerson(apiUrl);
    }
}