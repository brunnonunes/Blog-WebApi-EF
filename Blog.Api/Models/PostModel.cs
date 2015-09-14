using Blog.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class PostModelGet
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataCriacao { get; set; }

        public int UsarioId { get; set; }
        public string UsuarioLogin { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }

    public class PostModelInsert
    {        
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Corpo { get; set; }
     
        [Required]
        public int UsuarioId { get; set; }
    }
}