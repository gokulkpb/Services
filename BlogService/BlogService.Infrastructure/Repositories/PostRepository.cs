using BlogService.Application.DTOs;
using BlogService.Application.Interfaces;
using BlogService.Domain.Entities;
using BlogService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Infrastructure.Repositories
{
    public class PostRepository:IPostRepository
    {
        private readonly BlogDbContext _context;
        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreatePostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<Post?> GetPostById(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }
    }
}
