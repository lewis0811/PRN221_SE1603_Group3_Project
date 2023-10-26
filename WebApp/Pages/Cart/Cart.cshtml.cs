using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Pages.Cart
{
    public class CartModel : PageModel
    {
        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; }

        [BindProperty]
        public Order Order { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public CartModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet(int ServiceId, int LaundryStoreId, int OrderDetailId, int OrderId, int Quantity)
        {
            OrderDetails = _unitOfWork.OrderDetail.Get().AsQueryable()
                .Where(c => c.OrderId == OrderId)
                .Include(c => c.StoreService).ThenInclude(c => c.Service)
                .Include(c => c.StoreService).ThenInclude(c => c.LaundryStore)
                .ToList();

            Order =  _unitOfWork.Order.Get().AsQueryable()
                .Include(c => c.Customer)
                .Where(c => c.Id == OrderId)
                .FirstOrDefault();


        }

        public async Task<IActionResult> OnPostDeleteAsync(int id, IFormCollection data)
        {

            var entity = await _unitOfWork.OrderDetail.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (entity != null)
            {
                _unitOfWork.OrderDetail.Delete(entity);
                _unitOfWork.Save();
            }
            return RedirectToPage("/Cart/Cart", new { OrderId = entity.OrderId});
        }

        public async Task<IActionResult> OnPostUpdateOrderAsync()
        {
            var order = await _unitOfWork.Order.Get().AsQueryable().FirstOrDefaultAsync(c => c.Id == Order.Id);
            if (order != null)
            {
                order.TotalPrice = Order.TotalPrice;
                order.IsPaid = true;
            }

            _unitOfWork.Order.Update(order); _unitOfWork.Save();
            return RedirectToPage("/Order_Pages/Index", new {id = Order.Customer.ApplicationUserId});
        }
    }
}