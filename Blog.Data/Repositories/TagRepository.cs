using Blog.Data.DataSource;
using Blog.Data.Entities;

namespace Blog.Data.Repositories
{
    public class TagRepository : RepositoryBase<Tag>
    {
        private BlogContext blogContext { get; set; }

        public TagRepository(BlogContext context)
        {
            blogContext = context;
        }
    }
}
