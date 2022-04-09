using TweetBook.Domain;

namespace TweetBook.Services
{
    public class PostService : IPostService
    {
        private List<Post> _posts;

        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid(), Name = $"Post Name {i}" });
            }
        }
        public Post GetPost(Guid id)
        {
            return _posts.Find(x => x.Id == id);
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }

        public bool UpdatePost(Post post)
        {
            var isExists = GetPost(post.Id) != null;
            if (!isExists)
                return false;
            var index = _posts.FindIndex(x => x.Id == post.Id);
            _posts[index] = post;
            return true;
        }
    }
}
