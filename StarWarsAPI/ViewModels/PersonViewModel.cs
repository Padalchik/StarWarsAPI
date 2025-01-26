using StarWarsAPI.DTO;

namespace StarWarsAPI.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get;  }
    }
}
