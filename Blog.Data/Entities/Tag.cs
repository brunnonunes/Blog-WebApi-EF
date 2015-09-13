using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Descricao { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
