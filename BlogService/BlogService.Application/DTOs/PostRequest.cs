using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Application.DTOs
{
    public class PostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid BlogId { get; set; }

    }
}
