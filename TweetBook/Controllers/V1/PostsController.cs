﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetPostsAsync());
        }


        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = id,
                Name = postRequest.Name
            };

            var updated = await _postService.UpdatePostAsync(post);
            if (updated)
                return Ok(post);
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted =await _postService.DeletePostAsync(id);
            if (deleted)
                return NoContent();
            return NotFound();
        }


        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Name = postRequest.Name };
            await _postService.CreatePostAsync(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{id}", post.Id.ToString());
            var response = new PostResponse { Id = post.Id };
            return Created(locationUrl, response);
        }
    }
}
