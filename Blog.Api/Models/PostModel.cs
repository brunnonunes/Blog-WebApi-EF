using Blog.Data.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Api.Models
{
    // Envia os dados do post para o cliente.
    public class PostModelGetAllPosts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public string UserLogin { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }

    // Envia os dados para gravar um novo post.
    public class PostModelInsert
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}