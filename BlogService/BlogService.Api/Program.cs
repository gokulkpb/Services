
using Microsoft.EntityFrameworkCore;
using BlogService.Infrastructure.Data;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using AppBlogService = BlogService.Application.Services.BlogService;
using BlogService.Application.Interfaces;
using BlogService.Infrastructure.Repositories;
using BlogService.Application.Services;

namespace BlogService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            // Register EF Core DbContext with SQL Server
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IBlogService, AppBlogService>();
            builder.Services.AddScoped<IBlogRepository,BlogRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IPostService, PostService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Apply migrations
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
                dbContext.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
