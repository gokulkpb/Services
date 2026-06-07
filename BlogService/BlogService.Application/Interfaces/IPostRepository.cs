using BlogService.Application.DTOs;
using BlogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Application.Interfaces
{
    public interface IPostRepository
    {
        Task<Guid> CreatePostAsync(Post post);
        Task<Post?> GetPostById(Guid id);
    }
}
