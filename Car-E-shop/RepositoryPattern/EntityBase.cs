using System.ComponentModel.DataAnnotations;

namespace Car_E_shop.RepositoryPattern
{
    public class EntityBase
    {
        [Required]
        public int Id { get; set; }
    }
}
