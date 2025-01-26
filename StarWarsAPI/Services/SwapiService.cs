using StarWarsAPI.DTO;
using StarWarsAPI.Models;

namespace StarWarsAPI.Services;

public class SwapiService : ISwapiService
{
    private ISwapiClient _swapiClient;

    public SwapiService(ISwapiClient swapiClient)
    {
        _swapiClient = swapiClient;
    }

    public async Task<(Planet, List<Person>)> GetPlanetsWithPeople(int index)
    {
        var planet = await _swapiClient.GetPlanet(index);

        var residentsTasks = new List<Task<Person>>();
        foreach (var residentUrl in planet.Residents)
        {
            var resident = _swapiClient.GetPerson(residentUrl);
            residentsTasks.Add(resident);
        }
        await Task.WhenAll(residentsTasks);
        var residents = residentsTasks.Select(t => t.Result).ToList();
        return (planet, residents);
    }
}

public interface ISwapiService
{
    Task<(Planet, List<Person>)> GetPlanetsWithPeople(int index);
}