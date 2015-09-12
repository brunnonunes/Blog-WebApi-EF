
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        ICollection<TEntity> GetAll();
        TEntity GetById(int id);
        
    }
}