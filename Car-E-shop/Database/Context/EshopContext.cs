using Microsoft.EntityFrameworkCore;

namespace Car_E_shop.Database.Context
{
    public class EshopContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public EshopContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=Eshop;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        

    }
}
