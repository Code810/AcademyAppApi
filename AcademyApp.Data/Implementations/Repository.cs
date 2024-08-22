using AcademyApp.Core.Repositories;
using AcademyApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AcademyApp.Data.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AcademyContext _context;

        public Repository(AcademyContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        private readonly DbSet<T> _table;
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(T entity)
        {
            var result = _context.Entry(entity);
            result.State = EntityState.Added;
        }

        public async Task Delete(T entity)
        {
            var result = _context.Entry(entity);
            result.State = EntityState.Deleted;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes.Length > 0)
            {
                query = GetAllIncludes(includes);
            }
            return predicate == null ? await query.ToListAsync() : await query.Where(predicate).ToListAsync();
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes.Length > 0)
            {
                query = GetAllIncludes(includes);
            }
            return predicate == null ? await query.FirstOrDefaultAsync() : await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? false : await _table.AnyAsync(predicate);
        }

        public async Task Update(T entity)
        {
            var result = _context.Entry(entity);
            result.State = EntityState.Modified;
        }

        public IQueryable<T> GetAllIncludes(params string[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
