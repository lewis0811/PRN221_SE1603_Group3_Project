using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Pages.Services
{
    [Authorize(Roles = ("Customer, Admin"))]
    public class Details2Model : PageModel
    {
        [BindProperty]
        public string Error { get; set; }

        [BindProperty]
        public LaundryStore LaundryStore { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public Service Service { get; set; }

        [BindProperty]
        public List<LaundryStore> LaundryStores { get; set; }

        [BindProperty]
        public StoreService StoreService { get; set; }

        [BindProperty]
        public List<Order> Orders { get; set; }

        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; }

        [BindProperty]
        public List<StoreService> StoreServices { get; set; }


        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Details2Model(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IMapper mapper, SignInManager<IdentityUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id, string? error)
        {
            // Check Login
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("/Account/Login");
            }

            if(error != null)
            {
                Error = error;
            }

            Customer = await _unitOfWork.Customer.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.ApplicationUserId == _userManager.GetUserId(User));
            if (id == null)
            {
                return NotFound();
            }

            Service = await _unitOfWork.Service.Get().AsQueryable()
                .OrderBy(c => c.Name)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Service == null)
            {
                return NotFound();
            }

            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .Where(c => c.ServiceId == id)
                .FirstOrDefaultAsync();

            StoreServices = _unitOfWork.StoreService
                .Get().AsQueryable()
                .Include(c => c.LaundryStore)
                .Where(c => c.ServiceId == id)
                .ToList();

            LaundryStores = _unitOfWork.LaundryStore
                .GetAll()
                .ToList();

            var filterServiceByStore = new List<LaundryStore>();
            foreach (var store in StoreServices)
            {
                filterServiceByStore.Add(store.LaundryStore);
            }
            filterServiceByStore = LaundryStores.Except(filterServiceByStore).ToList();

            LaundryStores = LaundryStores.Except(filterServiceByStore).ToList();
            OrderDetail = new();

            return Page();
        }

        public async Task<IActionResult> OnPostCartAsync(int? id)
        {
            // Create a new OrderVM object and populate its properties
            var orderEntity = new OrderVM()
            {
                CustomerId = Customer.Id,
                OrderTime = DateTime.UtcNow,
                IsPaid = false,
            };

            // Create a new OrderDetailVM object and set its Quantity property
            var orderDetailEntity = new OrderDetailVM()
            {
                Quantity = OrderDetail.Quantity,
            };

            // ###################################
            // Retrieve the store being checked
            var storeBeingCheck = await _unitOfWork.LaundryStore.Get().AsQueryable()
                .Where(c => c.Id == LaundryStore.Id)
                .FirstOrDefaultAsync();

            // Retrieve the StoreService and StoreServices
            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .Include(c => c.LaundryStore).FirstOrDefaultAsync();
            StoreServices = _unitOfWork.StoreService
                .Get().AsQueryable()
                .Include(c => c.LaundryStore)
                .Where(c => c.ServiceId == id)
                .ToList();

            // Retrieve the OrderDetails
            OrderDetails = await _unitOfWork.OrderDetail.Get().AsQueryable()
                .Include(c => c.Order)
                .Include(c => c.StoreService)
                .ThenInclude(c => c.LaundryStore)
                .Where(c => c.StoreService.LaundryStore.Id == LaundryStore.Id
                    && c.Order.OrderStatus != Domain.Enums.OrderStatus.Collecting
                    && c.Order.OrderStatus != Domain.Enums.OrderStatus.Finished)
                .ToListAsync();

            // Create a new list to store Orders
            Orders = new List<Order>();
            foreach (var item in OrderDetails)
            {
                Orders.Add(item.Order);
            }

            // Filter out Orders with certain OrderStatus
            Orders = Orders
                .Where(c => c.OrderStatus != OrderStatus.Collecting
                && c.OrderStatus != OrderStatus.Finished)
                .GroupBy(c => c.Id)
                .Select(a => a.FirstOrDefault())
                .ToList();

            // Check if the store's capacity is reached
            var checkWorking = Orders.Where(c => c.OrderStatus == OrderStatus.Washing).ToList();
            if (storeBeingCheck.Capacity <= checkWorking.Count)
            {
                // Handle the case when the store's capacity is reached
                Customer = await _unitOfWork.Customer.Get().AsQueryable()
               .FirstOrDefaultAsync(c => c.ApplicationUserId == _userManager.GetUserId(User));
                if (id == null)
                {
                    return NotFound();
                }

                Service = await _unitOfWork.Service.Get().AsQueryable()
                    .OrderBy(c => c.Name)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (Service == null)
                {
                    return NotFound();
                }

                StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                    .Where(c => c.ServiceId == id)
                    .FirstOrDefaultAsync();

                StoreServices = _unitOfWork.StoreService
                    .Get().AsQueryable()
                    .Include(c => c.LaundryStore)
                    .Where(c => c.ServiceId == id)
                    .ToList();

                LaundryStores = _unitOfWork.LaundryStore
                    .GetAll()
                    .ToList();

                var filterServiceByStore = new List<LaundryStore>();
                foreach (var store in StoreServices)
                {
                    filterServiceByStore.Add(store.LaundryStore);
                }
                filterServiceByStore = LaundryStores.Except(filterServiceByStore).ToList();

                LaundryStores = LaundryStores.Except(filterServiceByStore).ToList();
                OrderDetail = new();
                ViewData["Error"] = $"{StoreService.LaundryStore.Name} is out of machine slot right now, please choose another store or try again later.";
                return RedirectToPage("/Services/Details2", new { id = id, error = ViewData["Error"].ToString() });
            }
            ////////////////////////////////////////////////////////////////////////////////

            // Check if the order is already paid
            var isPaid = _unitOfWork.Order.Get().AsQueryable().Any(c => c.IsPaid == false
            && c.CustomerId == orderEntity.CustomerId);
            if (!isPaid)
            {
                // If not paid, create a new order and set the orderDetailEntity's OrderId
                var order = _unitOfWork.Order.Add(_mapper.Map<Order>(orderEntity));
                _unitOfWork.Save();
                orderDetailEntity.OrderId = order.Id;
            }
            else
            {
                // If already paid, set the orderDetailEntity's OrderId to the first unpaid order's Id
                orderDetailEntity.OrderId = _unitOfWork.Order.Get().AsQueryable().FirstOrDefault(c => c.IsPaid == false).Id;
            }

            // Look for a matching StoreService
            var matchStoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.LaundryStoreId == LaundryStore.Id
                && c.ServiceId == Service.Id);
            if (matchStoreService != null)
            {
                // Calculate the TotalPrice based on the matching StoreService's properties
                orderDetailEntity.TotalPrice = matchStoreService.UnitPrice
                    != null
                    ? (matchStoreService.UnitPrice * OrderDetail.Quantity)
                    : (matchStoreService.Weight * OrderDetail.Quantity);
                orderDetailEntity.StoreServiceId = matchStoreService.Id;
            }

            // Check if the existService already exists
            var existService = await _unitOfWork.OrderDetail.Get().AsQueryable()
                .Include(c => c.StoreService).ThenInclude(c => c.Service)
                .FirstOrDefaultAsync(c => c.StoreServiceId == matchStoreService.Id
                && c.OrderId == orderDetailEntity.OrderId);

            int tempOrderDetailId = 0;
            int tempOrderId = 0;
            if (existService != null)
            {
                if (existService.Quantity >= 5)
                {
                    // Handle the case when the service in the cart reaches max capacity
                    ViewData["Error"] = $"Service: {existService.StoreService.Service.Name} has already reached max capacity in your cart.";
                    return RedirectToPage("/Services/Details2", new { id = id, error = ViewData["Error"].ToString() });
                }
                existService.Quantity += OrderDetail.Quantity;
                existService.TotalPrice = matchStoreService.UnitPrice
                    != null
                    ? (matchStoreService.UnitPrice * existService.Quantity)
                    : (matchStoreService.Weight * existService.Quantity);

                _unitOfWork.Save();
                tempOrderDetailId = existService.Id;
                tempOrderId = existService.OrderId;
            }
            else
            {
                // Create a new OrderDetail and save it
                var orderDetail = _unitOfWork.OrderDetail.Add(_mapper.Map<OrderDetail>(orderDetailEntity));
                _unitOfWork.Save();
                tempOrderDetailId = orderDetail.Id;
                tempOrderId = orderDetail.OrderId;
            }

            // Create a model object to pass to the RedirectToPageResult
            var model = new
            {
                ServiceId = Service.Id,
                LaundryStoreId = StoreService.LaundryStoreId,
                OrderId = tempOrderId,
                OrderDetailId = tempOrderDetailId,
                Quantity = OrderDetail.Quantity,
            };

            return new RedirectToPageResult("/Cart/Cart", model);
        }
    }
}