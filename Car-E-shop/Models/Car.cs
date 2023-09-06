using Car_E_shop.RepositoryPattern;
using System.ComponentModel.DataAnnotations;

namespace Car_E_shop.Models
{
    public class Car : EntityBase
    {
        [Required]
        public string Make { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;
        
        [Required]
        public DateTime YeatOfManufacture { get; set; } = default;

        [Required]
        public string BodyWork { get; set; } = string.Empty;
        
        [Required]
        public string Engine { get; set; } = string.Empty;
        
        [Required]
        public decimal Price { get; set; } = 0;

        [Required]
        public string State { get; set; } = string.Empty;

        public byte[]? Image { get; set; }

        [Required]
        public int UserId{ get; set; }

        public User? User{ get; set; }

    }

    public enum BodyWork
    {
        Sedan = 0,
        SUV = 1, 
        Hatchback = 2
    }

    public enum Engine
    {
        Diesel = 0,
        Hybrid = 1,
        Electro = 2
    }

    public enum State
    {
        New = 0,
        Used = 1,
        VeryOld = 2
    }
}
