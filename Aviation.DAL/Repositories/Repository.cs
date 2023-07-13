using Aviation.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Aviation.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
