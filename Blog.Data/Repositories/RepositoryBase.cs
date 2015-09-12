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
            using (var d = new BlogContext())
            {
                d.Entry(obj).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        public void Delete(TEntity obj)
        {
            using (var d = new BlogContext())
            {
                d.Entry(obj).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public void Update(TEntity obj)
        {
            using (var d = new BlogContext())
            {
                d.Entry(obj).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        public ICollection<TEntity> GetAll()
        {
            using (var d = new BlogContext())
            {
                return d.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var d = new BlogContext())
            {
                return d.Set<TEntity>().Find(id);
            }
        }
        
    }
}
