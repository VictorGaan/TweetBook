using Microsoft.Extensions.Configuration;
using TweetBook.Installers;

namespace TweetBook.Extensions
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IInstalller).IsAssignableFrom(x)
                && !x.IsInterface
                && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstalller>().ToList();
            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
