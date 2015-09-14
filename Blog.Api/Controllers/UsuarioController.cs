using Blog.Api.Models;
using Blog.Api.Utility;
using Blog.Data.Repositories;
using System.Web.Http;
using System.Web.Security;

namespace Blog.Api.Controllers
{
    [Authorize]
    [RoutePrefix("Blog/Usuario")]
    public class UsuarioController : ApiController
    {
        [Route("Login"), HttpPost, AllowAnonymous]
        public bool Login(UsuarioModelLogin model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UsuarioRepository = new UsuarioRepository();

                    var Usuario = UsuarioRepository.Authenticate(model.Login, Cryptography.GetMD5Hash(model.Senha));

                    if (Usuario != null)
                    {
                        //Gerando um Ticket de Acesso para o usuario.
                        FormsAuthentication.SetAuthCookie(Usuario.Login, false);

                        return true;
                    }

                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        //[Route("Login"), HttpPost, AllowAnonymous]
        //public string Login(UsuarioModelLogin model)
        //{
        //    if (model.Login.Equals("brunno") && model.Senha.Equals("123"))
        //    {
        //        //Gerando um Ticket de Acesso para o usuario.
        //        FormsAuthentication.SetAuthCookie(model.Login, false);

        //        return "Logou!";
        //    }
        //    else
        //    {
        //        return "Errou!!";
        //    }

        //}

        //[Route("EstouLogado"), HttpGet]
        //public string EstouLogado()
        //{
        //    return "Sim!";
        //}

    }
}
