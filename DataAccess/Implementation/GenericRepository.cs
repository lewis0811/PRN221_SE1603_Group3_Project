using DataAccess.Context;
using Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}