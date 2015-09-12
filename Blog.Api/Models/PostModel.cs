using System;

namespace Blog.Api.Models
{
    public class PostModelConsulta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}