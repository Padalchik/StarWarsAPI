namespace StarWarsAPI.DTO
{
    public record PersonDTO
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
