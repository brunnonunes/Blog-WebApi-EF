using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Titulo { get; set; }

        [StringLength(1000)]
        public string Corpo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
