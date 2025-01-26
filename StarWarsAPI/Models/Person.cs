public record Person
{
    public Person(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; }
}