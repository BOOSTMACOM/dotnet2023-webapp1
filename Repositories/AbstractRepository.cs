using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly WebApplication1Context _context;

        protected readonly DbSet<T> _dbSet;
        public AbstractRepository(WebApplication1Context context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T? Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Insert(T entity)
        {
            var e = _dbSet.Add(entity);
            _context.SaveChanges();
            return e.Entity;
        }
    }
}
