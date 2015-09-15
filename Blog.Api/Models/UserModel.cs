using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    // Envia os dados para a camada de dados para realizar a autenticação 
    // do usuário e devolve os dados do usuário logado para o cliente.
    public class UserModelLogin
    {
        public int Id { get; set; }        
        public string Login { get; set; }
        public string Password { get; set; }
        public int PerfilId { get; set; }
        public string LoginStatusMessage { get; set; }
    }
}