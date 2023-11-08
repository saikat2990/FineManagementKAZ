using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> All();
        IQueryable<T> All(Expression<Func<T, bool>> predicate);
        IQueryable<T> All(params Expression<Func<T, object>>[] includeProperties);

        T Find(Int64 id);
        T Find(int id, Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> expression);

        Task<T> FindAsync(int id);
        Task<T> FindAsync(int id, Expression<Func<T, bool>> predicate);

        void Add(T entity);
        Task AddAsync(T entity);

        void AddRange(List<T> entities);
        Task AddRangeAsync(List<T> entities);

        void Update(T entity);
        void UpdateRange(List<T> entities);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(List<T> entities);
        void Save();
        Task SaveAsync();
    }
}
