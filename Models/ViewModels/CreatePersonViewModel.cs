using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public int Phone { get; set; }

        public string City { get; set; }

        public CreatePersonViewModel() 
        { 
        
        }

        public CreatePersonViewModel(string name, int phone, string city)
        {
            Name = name;
            Phone = phone;
            City = city;
        }

    }
}
