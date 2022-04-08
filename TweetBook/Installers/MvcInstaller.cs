using Microsoft.OpenApi.Models;

namespace TweetBook.Installers
{
    public class MvcInstaller : IInstalller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
           

            services.AddControllersWithViews(option =>
            {
                option.EnableEndpointRouting = false;
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "TweetBook API", Version = "v1" });
            });

        }
    }
}
