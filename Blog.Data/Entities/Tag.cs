using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entities
{
    public class Tag
    {
        [Key]        
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(250)]
        public string Descricao { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
