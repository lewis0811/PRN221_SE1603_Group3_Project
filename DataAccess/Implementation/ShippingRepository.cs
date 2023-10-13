using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class ShippingRepository : GenericRepository<Shipping>, IShippingRepository
    {
        public ShippingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
