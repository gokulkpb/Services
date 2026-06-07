using BlogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Application.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync();
        Task<Blog?> GetBlogByIdAsync(Guid Id);
        Task<Guid> CreateBlogAsync(Blog blog);
    }
}
