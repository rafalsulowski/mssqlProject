using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace mssqlProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db=db;
            this.dbSet=_db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<RepositoryResponse<List<T>>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            var data = await query.ToListAsync();
            return new RepositoryResponse<List<T>> { Data = data };
        }

        public async Task<RepositoryResponse<T>> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            var data = await query.FirstOrDefaultAsync();
            return new RepositoryResponse<T> { Data = data };
        }

        public void Remove(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach(T entity in entities)
            {
                if (_db.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
            }
            
            dbSet.RemoveRange(entities);
        }

        public async Task<RepositoryResponse<bool>> SaveChangesAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
            } catch (Exception e )
            {
                return new RepositoryResponse<bool> { 
                    Success = false,
                    Data = false,
                    Message = e.Message
                };
            }
            
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
