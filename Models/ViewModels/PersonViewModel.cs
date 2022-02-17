using System.Collections.Generic;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.ViewModels
{
    public class PersonViewModel
    {
        public List<Person> People { get; set; }
        public CreatePersonViewModel CreateViewModel { get; set; }

    }
}
