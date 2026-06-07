using BlogService.Application.DTOs;
using BlogService.Application.Interfaces;
using BlogService.Domain.Entities;


namespace BlogService.Application.Services
{
    public interface IBlogService
    {
        // Define service methods here, e.g.:
        Task<Guid> CreateBlogAsync(string title);
        Task<BlogDto> GetBlogByIdAsync(Guid blogId);
        Task<IEnumerable<BlogDto>> GetAllBlogsAsync();
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

        public async Task<IEnumerable<BlogDto>> GetAllBlogsAsync()
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();

            var blogList = blogs.Select(blog => new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                UserName = blog.UserName,
                Created = blog.CreatedAt,
                Posts = blog.Posts.Select(post => new PostDTO
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Published = post.PublishedAt,
                }).ToList()
            }).ToList();

            return blogList;

        }

        public async Task<BlogDto> GetBlogByIdAsync(Guid blogId)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(blogId);

            return new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Created = blog.CreatedAt,
                Posts = blog.Posts.Select(post => new PostDTO
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Published = post.PublishedAt,
                }).ToList(),
            };
        }

        public async Task<Guid> CreateBlogAsync(string title)
        {
            var blog = new Blog
            {
                Id = Guid.NewGuid(),
                Title = title,
                CreatedAt = DateTime.Now,
                UserName = "gokulkpb"
            };

            var result = await _blogRepository.CreateBlogAsync(blog);

            return result;
        }

    }
}
