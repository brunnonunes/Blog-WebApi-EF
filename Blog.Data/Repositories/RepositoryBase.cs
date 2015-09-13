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
        public void Insert(TEntity obj)
        {
            using (var Context = new BlogContext())
            {
                Context.Entry(obj).State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void Delete(TEntity obj)
        {
            using (var Context = new BlogContext())
            {
                Context.Entry(obj).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public void Update(TEntity obj)
        {
            using (var Context = new BlogContext())
            {
                Context.Entry(obj).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public ICollection<TEntity> GetAll()
        {
            using (var Context = new BlogContext())
            {
                return Context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var Context = new BlogContext())
            {
                return Context.Set<TEntity>().Find(id);
            }
        }
        
    }
}
