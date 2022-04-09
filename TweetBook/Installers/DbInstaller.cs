using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TweetBook.Data;
using TweetBook.Services;

namespace TweetBook.Installers
{
    public class DbInstaller : IInstalller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("SqlServerConnection");
            var connectionString = configuration.GetConnectionString("NpgsqlConnection");
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(connectionString));
                //options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IPostService, PostService>(); 
        }
    }
}
