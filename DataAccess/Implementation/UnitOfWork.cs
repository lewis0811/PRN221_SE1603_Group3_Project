using DataAccess.Context;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Order = new OrderRepository(_context);
            Service = new ServiceRepository(_context);
            Customer = new CustomerRepository(_context);
            LaundryStore = new LaundryStoreRepository(_context);
            Staff = new StaffRepository(_context);
            Shipping = new ShippingRepository(_context);
            StoreService = new StoreServiceRepository(_context);
            LaundryStore = new LaundryStoreRepository(_context);
            User = new ApplicationUserRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);

        }

        public IApplicationUserRepository User {  get; set; }
        public IServiceRepository Service {  get; set; }
        public IOrderRepository Order { get; set; }

        public ICustomerRepository Customer { get; set; }

        public ILaundryStoreRepository LaundryStore { get; set; }

        public IStaffRepository Staff { get; set; }

        public IShippingRepository Shipping { get; set; }

        public IStoreServiceRepository StoreService { get; set; }

        public IOrderDetailRepository OrderDetail { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
