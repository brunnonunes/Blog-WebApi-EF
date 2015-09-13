using Blog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataCriacao { get; set; }

        public int UsarioId { get; set; }
        public string UsuarioLogin { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
