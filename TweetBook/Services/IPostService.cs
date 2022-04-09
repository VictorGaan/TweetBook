using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IPostService
    {
        public Task<List<Post>> GetPostsAsync();
        public Task<Post> GetPostByIdAsync(Guid id);
        public Task<bool> UpdatePostAsync(Post post);
        public Task<bool> DeletePostAsync(Guid id);
        public Task<bool> CreatePostAsync(Post post);
    }
}
