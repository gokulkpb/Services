using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Application.DTOs
{
    public class BlogDto
    {
        //DTO request and response properties
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty; 
        public DateTime Created { get; set; }
        public ICollection<PostDTO> Posts { get; set; } = new List<PostDTO>();


    }
}
