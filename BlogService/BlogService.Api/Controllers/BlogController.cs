using BlogService.Application.DTOs;
using BlogService.Application.Services;
using BlogService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogService.Api.Controllers
{
    
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
            
        }
        // GET: api/<BlogController>
        [HttpGet("api/blogs")]
        public async Task<IEnumerable<BlogDto>> GetAllBlogs()
        {
            return await _blogService.GetAllBlogsAsync();
        }

        // GET api/<BlogController>/5
        [HttpGet("api/blog/{id}")]
        public async Task<BlogDto> GetBlogById(Guid id)
        {
            return await _blogService.GetBlogByIdAsync(id);
        }

        [HttpPost("api/blog")]
        public async Task<IActionResult> CreateBlog(string title)
        {
            var result = await _blogService.CreateBlogAsync(title);
            return Ok(result);
        }
    }
}
