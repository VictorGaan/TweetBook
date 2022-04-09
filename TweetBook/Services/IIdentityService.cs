using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IIdentityService
    {
        public Task<AuthentificationResult> RegisterAsync(string email, string password);
    }
}
