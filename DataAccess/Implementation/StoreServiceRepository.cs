using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;

namespace DataAccess.Implementation
{
    public class StoreServiceRepository : GenericRepository<StoreService>, IStoreServiceRepository
    {
        public StoreServiceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}