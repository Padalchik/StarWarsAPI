namespace StarWarsAPI.DTO
{
    public record PeopleDTO
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
