using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts.Requests;
using TweetBook.Contracts.Responses;
using TweetBook.Contracts.V1;
using TweetBook.Domain;
using TweetBook.Services;

namespace TweetBook.Controllers.V1
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }


        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid id)
        {
            var post = _postService.GetPost(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = id,
                Name = postRequest.Name
            };

            var updated = _postService.UpdatePost(post);
            if (updated)
                return Ok(post);
            return NotFound();
        }


        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };
            if (post.Id != Guid.Empty)
            {
                post.Id = Guid.NewGuid();
            }
            _postService.GetPosts().Add(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{id}", post.Id.ToString());
            var response = new PostResponse { Id = post.Id };
            return Created(locationUrl, response);
        }
    }
}
