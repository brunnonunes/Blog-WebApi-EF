
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Descricao { get; set; }
                
    }
}
