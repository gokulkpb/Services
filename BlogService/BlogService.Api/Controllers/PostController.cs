using BlogService.Application.DTOs;
using BlogService.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogService.Api.Controllers
{ 
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        // POST api/<PostController>
        [HttpPost("api/post")]
        public async Task<IActionResult> CreatePost(PostRequest request)
        {
            var result = await _postService.CreatePostAsync(request);
            return Ok(result);
        }

        [HttpGet("api/post/{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var result = await _postService.GetPostById(id);
            return Ok(result);
        }
    }
}
