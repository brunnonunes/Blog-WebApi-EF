
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        
    }
}
