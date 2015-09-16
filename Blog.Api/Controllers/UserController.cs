using Blog.Api.Models;
using Blog.Data.Repositories;
using System.Web.Http;
using System.Web.Security;

namespace Blog.Api.Controllers
{
    [Authorize]
    [RoutePrefix("Blog/User")]
    public class UserController : ApiController
    {
        [Route("Login"), HttpGet, AllowAnonymous]
        public UserModelLogin Login([FromUri]UserModelLogin model)
        {
            var UserModelLogin = new UserModelLogin();

            if (ModelState.IsValid)
            {
                try
                {
                    var UserRepository = new UserRepository();

                    //var User = UserRepository.Authenticate(model.Login, Cryptography.GetMD5Hash(model.Password));
                    var User = UserRepository.Authenticate(model.Login, model.Password);
                                       
                    if (User != null)
                    {
                        //Gerando um Ticket de Acesso para o usuário.
                        FormsAuthentication.SetAuthCookie(User.Login, false);

                        UserModelLogin.Id = User.Id;
                        UserModelLogin.Login = User.Login;
                        UserModelLogin.PerfilId = User.PerfilId; 
                        UserModelLogin.LoginStatusMessage = "Login realizado com sucesso!";

                        return UserModelLogin;
                    }
                    else
                    {
                        UserModelLogin.LoginStatusMessage = ("Cadastro não encontrado.");

                        return UserModelLogin;
                    }
                }
                catch
                {
                    UserModelLogin.LoginStatusMessage = ("Erro, não foi possível realizar o login.");

                    return UserModelLogin;
                }
            }

            UserModelLogin.LoginStatusMessage = ("Insira login e senha.");

            return UserModelLogin;
        }
    }
}
