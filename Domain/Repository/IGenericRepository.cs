using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
