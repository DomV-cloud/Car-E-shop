using Microsoft.EntityFrameworkCore;

namespace Car_E_shop.Database.Context
{
    public class EshopContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=Eshop;Trusted_Connection=True;TrustServerCertificate=True;");
        }


    }
}
