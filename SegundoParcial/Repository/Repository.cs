using System.Linq.Expressions;
using SegundoParcial.Data;
using SegundoParcial.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace SegundoParcial.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet; 

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }


        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
           IQueryable<T> query = dbSet;

            if (includeProperties != null) {
                foreach (var prop in includeProperties.Split(',',StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
           return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }


    }
}
