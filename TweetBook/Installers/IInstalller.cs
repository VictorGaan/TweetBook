namespace TweetBook.Installers
{
    public interface IInstalller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
