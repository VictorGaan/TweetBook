using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IPostService
    {
        public List<Post> GetPosts();
        public Post GetPost(Guid id);
    }
}
