using BlogService.Application.Interfaces;
using BlogService.Domain.Entities;
using BlogService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    }
}
