namespace StarWarsAPI.ViewModels
{
    public class PlanetViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Информация о гравитации
        /// </summary>
        public string Gravity { get; }

        /// <summary>
        /// Ссылки на жителей
        /// </summary>
        public IReadOnlyList<PersonViewModel> Residents { get; }

        public PlanetViewModel(int id, string name, string gravity, IReadOnlyList<PersonViewModel> residents)
        {
            Id = id;
            Name = name;
            Gravity = gravity;
            Residents = residents;
        }
    }
}
