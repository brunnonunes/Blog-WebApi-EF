using System.Web.Http;

namespace Blog.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Blog/Usuario")]
    public class UsuarioController : ApiController
    {

        [Route("Mensagem")]
        public string GetValues()
        {
            return "Bem vindo ao WebApi!";
        }

        //Usuario[] users = { 
        //    new Usuario { Id = 1, Login = "Tomato Soup", Senha = "Groceries"}, 
        //    new Usuario { Id = 2, Login = "Yo-yo", Senha = "Toys"}, 
        //    new Usuario { Id = 3, Login = "Hammer", Senha = "Hardware"} 
        //};

        //[Route("getall")]
        //public IEnumerable<Usuario> GetAllUsuarios()
        //{
        //    return users;
        //}

        //[Route("getusuariobyid")] 
        //public IHttpActionResult GetUsuario(int id)
        //{
        //    var user = users.FirstOrDefault((p) => p.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

    }
}
