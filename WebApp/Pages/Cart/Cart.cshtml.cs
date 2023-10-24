using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Pages.Cart
{
    public class CartModel : PageModel
    {
        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public CartModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int ServiceId, int LaundryStoreId, int OrderDetailId,int OrderId, int Quantity)
        {
            OrderDetails = _unitOfWork.OrderDetail.Get().AsQueryable()
                .Where(c => c.OrderId == OrderId)
                .Include(c => c.StoreService).ThenInclude(c => c.Service)
                .Include(c => c.StoreService).ThenInclude(c => c.LaundryStore)
                .ToList();
        }
    }
}