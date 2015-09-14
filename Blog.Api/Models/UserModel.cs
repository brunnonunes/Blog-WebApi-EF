using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class UserModelLogin
    {
        [Required(ErrorMessage = "Informe o login de acesso.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha de acesso.")]
        public string Password { get; set; }
    }
}