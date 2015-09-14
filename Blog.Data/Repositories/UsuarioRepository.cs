
using System.Collections.Generic;
using System.Linq;
using Blog.Data.DataSource;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public Usuario Authenticate(string Login, string Senha)
        {
            using (var Context = new BlogContext())
            {
                return Context.Usuario.FirstOrDefault(u => u.Login.Equals(Login) & u.Senha.Equals(Senha));
            }
        }
    }
}
