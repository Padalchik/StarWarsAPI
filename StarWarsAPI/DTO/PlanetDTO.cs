namespace StarWarsAPI.DTO
{
    public record PlanetDTO
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Информация о гравитации
        /// </summary>
        public string Gravity { get; set; } = string.Empty;

        /// <summary>
        /// Ссылки на жителей
        /// </summary>
        public List<string> Residents { get; set; } = new List<string>();
    }
}
