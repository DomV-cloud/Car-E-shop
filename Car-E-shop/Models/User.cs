using Car_E_shop.RepositoryPattern;
using System.ComponentModel.DataAnnotations;

namespace Car_E_shop.Models
{
    public class User: EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty; 
        
        [Required]
        public string Surname { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Phone { get; set; } = 0;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public string Roles { get; set; } = string.Empty;


        public List<Car>? CarsForSale { get; set; }
    }

    public enum Roles
    {
        Admin = 0,
        Customer = 1,
        Saler = 2
    }
}
