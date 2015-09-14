using Blog.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class PostModelGet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public string UserLogin { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }

    public class PostModelInsert
    {        
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
     
        [Required]
        public int UserId { get; set; }
    }
}