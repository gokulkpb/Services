using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Application.DTOs
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
