using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        //Navigation property
        public ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
