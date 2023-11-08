using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories.Base;

namespace Repositories.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public IQueryable<T> All()
        {
            return _entities;
        }
        public IQueryable<T> All(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = All();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable;
        }

        public IQueryable<T> All(Expression<Func<T, bool>> predicate)
        {
            return All().Where(predicate);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression);
        }


        public T Find(long id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public T Find(int id, Expression<Func<T, bool>> predicate)
        {
            return All().Where(predicate).FirstOrDefault(x => x.Id == id);
        }
        public T Find(Expression<Func<T, bool>> expression)
        {
            return _entities.FirstOrDefault(expression);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> FindAsync(int id, Expression<Func<T, bool>> predicate)
        {
            return await All().Where(predicate).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            // _context.Add(entity);
            _entities.Add(entity);
            SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.AddAsync(entity);
        }

        public void AddRange(List<T> entities)
        {
            _context.AddRange(entities);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _context.UpdateRange(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Update(entity);
            await SaveAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            List<T> _entities = new List<T>();
            foreach (var item in entities)
            {

                _entities.Add(item);
            }

            _context.UpdateRange(_entities);
            await SaveAsync();
        }

        public void Remove(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
            SaveChanges();
        }

        public void RemoveRange(List<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}