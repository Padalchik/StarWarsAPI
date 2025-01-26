namespace StarWarsAPI.Models;

public class Planet
{
    public int Id { get; }
    public string Name { get; }
    public string Gravity { get; }
    public List<Uri> Residents { get; }

    public Planet(int id, string name, string gravity, List<Uri> residents)
    {
        Name = name;
        Gravity = gravity;
        Residents = residents;
        Id = id;
    }

    public Planet(int id, string name, string gravity, List<string> residents)
    {
        Name = name;
        Gravity = gravity;
        Id = id;
        Residents = residents.Select(r => new Uri(r)).ToList();
    }
}
