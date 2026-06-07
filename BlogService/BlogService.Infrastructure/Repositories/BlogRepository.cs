using BlogService.Application.Interfaces;
using BlogService.Domain.Entities;
using BlogService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace BlogService.Infrastructure.Repositories
{
    public class BlogRepository:IBlogRepository
    {
        private readonly BlogDbContext _context;
        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await _context.Blogs
                .Include(b => b.Posts)
                .ToListAsync();
        }

        public async Task<Blog?> GetBlogByIdAsync(Guid Id)
        {
            return await _context.Blogs
                .Where(b => b.Id == Id)
                .Include(b => b.Posts)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateBlogAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog.Id;
        }
    }
}
