using BlogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
// ...existing usings

namespace BlogService.Infrastructure.Data
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>(b =>
            {
                b.HasKey(x => x.Id);

                b.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property(x => x.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property(x => x.CreatedAt)
                    .IsRequired();
            });

            modelBuilder.Entity<Post>(p =>
            {
                p.HasKey(x => x.Id);

                p.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                p.Property(x => x.Content)
                    .IsRequired();

                p.Property(x => x.PublishedAt)
                    .IsRequired();

                p.HasOne(x => x.Blog)
                    .WithMany(b => b.Posts)
                    .HasForeignKey(x => x.BlogId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }


    }
}
