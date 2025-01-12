using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repostories;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositeries
{
    public class GenericRepository<T>(BlogAppDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table= _context.Set<T>();
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            
            Table.Remove(entity);

        }

        public async Task DeleteAsync(int id)
        {
            await Table.Where(x=> x.Id==id).ExecuteDeleteAsync();
            //T? entity = await GetByIdAsync(id);
            //Delete(entity!);
        }

        public IQueryable<T> GetAll()
         => Table.AsQueryable();
        public async Task<T?> GetByIdAsync(int id)
          =>  await Table.FindAsync(id);

    

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
         => Table.Where(expression).AsQueryable();

        public Task<bool> IsExistAsync(int id)
       => Table.AnyAsync(t=> t.Id==id);

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        => await Table.AnyAsync(expression);

        public Task<int> SaveAsync()
        => _context.SaveChangesAsync();
    }
}
