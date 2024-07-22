using Istka_Group4_FoodOrdering_DataAccess.Contexts;
using Istka_Group4_FoodOrdering_Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Istka_Group4_FoodOrdering_DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly FoodDbContext _context;
        private readonly DbSet<T> _dbSet;
       
        public Repository(FoodDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddNormal(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }


        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            if (filter == null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (orderby != null)
                query = orderby(query);
            foreach (var table in includes)
            {
                query = query.Include(table);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        //async Task IRepository<T>.UpdateAsync(T entity)
        //{
        //    await _dbSet.Update(entity);
        //}


    }
}
