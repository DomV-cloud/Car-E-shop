using Car_E_shop.Database.Context;

namespace Car_E_shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<EshopContext>();
            services.AddSingleton(Configuration);

        }


    }
}
