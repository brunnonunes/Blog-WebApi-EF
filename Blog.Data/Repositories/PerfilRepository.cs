using Blog.Data.DataSource;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class PerfilRepository : RepositoryBase<Perfil>
    {
        private BlogContext blogContext { get; set; }

        public PerfilRepository(BlogContext context)
        {
            blogContext = context;
        }
    }
}
