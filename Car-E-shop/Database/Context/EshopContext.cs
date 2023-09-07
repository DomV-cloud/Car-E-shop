using Car_E_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_E_shop.Database.Context
{
    public class EshopContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public EshopContext(DbContextOptions<EshopContext> options)
        : base(options)
        {
        }





    }
}
