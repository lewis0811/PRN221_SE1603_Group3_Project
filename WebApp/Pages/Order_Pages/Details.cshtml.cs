using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;
using WebApp.ViewModels;

namespace WebApp.Pages.Order_Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; }

        [BindProperty]
        public Order Order { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void  OnGetAsync(int? id)
        {
            OrderDetails = _unitOfWork.OrderDetail.Get().AsQueryable()
                .Where(c => c.OrderId == id)
                .Include(c => c.StoreService).ThenInclude(c => c.Service)
                .Include(c => c.StoreService).ThenInclude(c => c.LaundryStore)
                .ToList();

            Order = _unitOfWork.Order.Get().AsQueryable()
                .Include(c => c.Customer)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }
    }
}
