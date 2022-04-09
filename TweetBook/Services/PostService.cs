using TweetBook.Data;
using TweetBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace TweetBook.Services
{
    public class PostService : IPostService
    {
        //private List<Post> _posts;
        private readonly DataContext _context;
        public PostService(DataContext context)
        {
            _context = context;
            //_posts = new List<Post>();
            //for (int i = 0; i < 5; i++)
            //{
            //    _posts.Add(new Post { Id = Guid.NewGuid(), Name = $"Post Name {i}" });
            //}
        }
        public async Task<List<Post>> GetPostsAsync() => await _context.Posts.ToListAsync();

        public async Task<Post> GetPostByIdAsync(Guid id) => await _context.Posts.SingleOrDefaultAsync(post => post.Id == id);

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            var added = await _context.SaveChangesAsync();
            return added > 0;
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<bool> DeletePostAsync(Guid id)
        {
            var post = await GetPostByIdAsync(id);
            if(post==null)
                return false;
            _context.Posts.Remove(post);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
