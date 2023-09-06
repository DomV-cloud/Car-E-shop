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
            // Registruj IConfiguration
            services.AddSingleton(Configuration);

            // Další konfigurace služeb...
        }
    }
}
