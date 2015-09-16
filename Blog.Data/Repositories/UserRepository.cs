using System.Linq;
using Blog.Data.DataSource;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        private BlogContext blogContext { get; set; }

        public UserRepository(BlogContext context)
        {
            blogContext = context;
        }

        public User Authenticate(string Login, string Password)
        {
            using (blogContext)
            {
                return blogContext.User.Include("Perfil").FirstOrDefault(u => u.Login.Equals(Login) & u.Password.Equals(Password));
            }
        }
    }
}
