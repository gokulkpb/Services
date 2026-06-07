using BlogService.Application.DTOs;
using BlogService.Application.Interfaces;
using BlogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Application.Services
{
    
    public interface IPostService
    {
        Task<Guid> CreatePostAsync(PostRequest post);
        Task<PostDTO> GetPostById(Guid id);
    }
    public class PostService:IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Guid> CreatePostAsync(PostRequest postRequest)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Title = postRequest.Title,
                PublishedAt = DateTime.Now,
                Content = postRequest.Content,
                BlogId = postRequest.BlogId
                
            };
            var result = await _postRepository.CreatePostAsync(post);
            return result;
        }

        public async Task<PostDTO> GetPostById(Guid id)
        {
            var post = await _postRepository.GetPostById(id);

            return new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Published = post.PublishedAt,
                BlogID = post.BlogId
            };
        }


    }
}
