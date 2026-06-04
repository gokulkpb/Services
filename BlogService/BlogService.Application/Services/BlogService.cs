using BlogService.Application.Interfaces;
using BlogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Application.Services
{
    public interface IBlogService
    {
        // Define service methods here, e.g.:
        // Task<BlogDto> CreateBlogAsync(CreateBlogRequest request);
        // Task<BlogDto> GetBlogByIdAsync(Guid blogId);
        Task<IEnumerable<Blog>> GetAllBlogsAsync();
        // Task UpdateBlogAsync(Guid blogId, UpdateBlogRequest request);
        // Task DeleteBlogAsync(Guid blogId);
    }
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await _blogRepository.GetAllBlogsAsync();
        }

    }
}
