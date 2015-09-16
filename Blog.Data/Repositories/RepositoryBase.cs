using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Blog.Data.DataSource;
using Blog.Data.Interfaces;

namespace Blog.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        private BlogContext blogContext { get; set; }

        public RepositoryBase(BlogContext context)
        {
            blogContext = context;
        }

        public RepositoryBase() { }

        public void Insert(TEntity obj)
        {
            using (blogContext)
            {
                blogContext.Entry(obj).State = EntityState.Added;
                blogContext.SaveChanges();
            }
        }

        public void Delete(TEntity obj)
        {
            using (blogContext)
            {
                blogContext.Entry(obj).State = EntityState.Deleted;
                blogContext.SaveChanges();
            }
        }

        public void Update(TEntity obj)
        {
            using (blogContext)
            {
                blogContext.Entry(obj).State = EntityState.Modified;
                blogContext.SaveChanges();
            }
        }

        public ICollection<TEntity> GetAll()
        {
            using (blogContext)
            {
                return blogContext.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (blogContext)
            {
                return blogContext.Set<TEntity>().Find(id);
            }
        }

    }
}
