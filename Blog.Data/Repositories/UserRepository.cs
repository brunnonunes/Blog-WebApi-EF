
using System.Collections.Generic;
using System.Linq;
using Blog.Data.DataSource;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public User Authenticate(string Login, string Password)
        {
            using (var Context = new BlogContext())
            {
                return Context.User.FirstOrDefault(u => u.Login.Equals(Login) & u.Password.Equals(Password));
            }
        }
    }
}
