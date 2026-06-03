using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }


        //Foreign key to Blog
        public Guid BlogId { get; set; }

        //Navigation property
        public Blog Blog { get; set; } = null!;
    }
}
