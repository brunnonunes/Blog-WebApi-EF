using Blog.Api.Models;
using Blog.Api.Utility;
using Blog.Data.Repositories;
using System.Web.Http;
using System.Web.Security;

namespace Blog.Api.Controllers
{
    [Authorize]
    [RoutePrefix("Blog/User")]
    public class UserController : ApiController
    {
        [Route("Login"), HttpPost, AllowAnonymous]
        public bool Login(UserModelLogin model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UserRepository = new UserRepository();

                    var User = UserRepository.Authenticate(model.Login, Cryptography.GetMD5Hash(model.Password));

                    if (User != null)
                    {
                        //Gerando um Ticket de Acesso para o usuario.
                        FormsAuthentication.SetAuthCookie(User.Login, false);

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
        //public string Login(UserModelLogin model)
        //{
        //    if (model.Login.Equals("brunno") && model.Password.Equals("123"))
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
