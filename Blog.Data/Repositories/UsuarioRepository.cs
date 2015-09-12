
using System.Collections.Generic;
using System.Linq;
using Blog.Data.DataSource;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {

        public ICollection<Usuario> BuscarPorLogin(string login)
        {

            using (var d = new BlogContext())
            {
                return d.Usuario.Where(u => u.Login.Contains(login)).OrderBy(u => u.Login).ToList();
            }

        }

    }
}
