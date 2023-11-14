using Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Configuration;
using WebApp.ViewModels;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Service> Service { get; set; }
        public IList<OrderDetail> OrderDetails{ get; set; }
        public IList<Order> Orders { get; set; }
        public IList<StoreService> StoreServices { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public OrderVM OrderVM { get; set; }
        [BindProperty]
        public LaundryStore LaundryStore { get; set; }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            Service = await _unitOfWork.Service.Get().AsQueryable()
                .ToListAsync();

            OrderDetails = await _unitOfWork.OrderDetail.Get().AsQueryable()
                .Include(c => c.Order)
                .Include(c => c.StoreService)
                .ThenInclude(c => c.LaundryStore)
                .Where(c => c.StoreService.LaundryStore.ApplicationUserId == _userManager.GetUserId(User)
                    && c.Order.OrderStatus != Domain.Enums.OrderStatus.Collecting
                    && c.Order.OrderStatus != Domain.Enums.OrderStatus.Finished)
                .ToListAsync();

            Order = new();

            LaundryStore = await _unitOfWork.LaundryStore.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.ApplicationUserId == _userManager.GetUserId(User));

            await ListOrderByRole();

        }

        private async Task ListOrderByRole()
        {
            if (User.IsInRole("LaundryStore"))
            {

                Orders = new List<Order>();
                foreach (var item in OrderDetails)
                {
                    Orders.Add(item.Order);
                }

                Orders = Orders
                    .Where(c => c.OrderStatus != OrderStatus.Collecting
                    && c.OrderStatus != OrderStatus.Finished)
                    .GroupBy(c => c.Id)
                    .Select(a => a.FirstOrDefault())
                    .OrderByDescending(c => c.OrderStatus == OrderStatus.Washing)
                    .ToList();

                var checkWorking = Orders.Where(c => c.OrderStatus == OrderStatus.Washing).ToList();
                if (LaundryStore.Capacity <= checkWorking.Count)
                {
                     LaundryStore.Status = false;
                }
                else
                {
                     LaundryStore.Status = true;
                }
                //_unitOfWork.LaundryStore.Update(LaundryStore);
                //_unitOfWork.Save();
            }
            else if(User.IsInRole("Staff"))
            {
                Orders = await _unitOfWork.Order.Get().AsQueryable()
                .Where(c => c.IsPaid == true
                && c.OrderStatus != Domain.Enums.OrderStatus.Washing)
                .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostSaveAsync(int id)
        {
            OrderDetails = await _unitOfWork.OrderDetail.Get().AsQueryable()
                .Include(c => c.Order)
                .Include(c => c.StoreService)
                .ThenInclude(c => c.LaundryStore)
                .Where(c => c.StoreService.LaundryStore.ApplicationUserId == _userManager.GetUserId(User)
                    && c.Order.OrderStatus != Domain.Enums.OrderStatus.Collecting
                    && c.Order.OrderStatus != Domain.Enums.OrderStatus.Finished)
                .ToListAsync();

            await ListOrderByRole();

            var entity = await _unitOfWork.Order.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (entity != null)
            {
                switch (entity.OrderStatus)
                {
                    case OrderStatus.Collecting:
                        entity.OrderStatus = OrderStatus.Washing; break;
                    case OrderStatus.Washing:
                        entity.OrderStatus = OrderStatus.Washed; break;
                    case OrderStatus.Washed:
                        entity.OrderStatus = OrderStatus.Finished; break;
                }

                _unitOfWork.Order.Update(entity);
                _unitOfWork.Save();
            }
            return RedirectToPage("./Index/", new {storeId = _userManager.GetUserId(User)});
        }
    }
}
