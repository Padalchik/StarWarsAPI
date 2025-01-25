namespace StarWarsAPI.ViewModels
{
    public class PlanetViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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
        public IReadOnlyList<PeopleViewModel> Residents => _residents.AsReadOnly();
        private readonly List<PeopleViewModel> _residents = new();

        //Добавление жителей
        public void AddResidence(PeopleViewModel peopleViewModel)
        {
            _residents.Add(peopleViewModel);
        }
    }
}
