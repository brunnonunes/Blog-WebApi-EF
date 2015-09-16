using Blog.Data.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Data.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public string UserLogin { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
