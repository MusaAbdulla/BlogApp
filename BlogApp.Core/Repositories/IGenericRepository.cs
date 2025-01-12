using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repostories
{
    public interface IGenericRepository<T> where T : BaseEntity ,new ()
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
        Task<int> SaveAsync();
        Task<bool> IsExistAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    }
}
