using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IServiceRepository Service {  get; }
        public ICustomerRepository Customer { get; }
        public ILaundryStoreRepository LaundryStore { get; }
        public IStaffRepository Staff { get; }
        public IShippingRepository Shipping { get; }
        public IStoreServiceRepository StoreService { get; }
        public ILaundryStoreRepository LandryStore { get; }

        public void Save();
    }
}
