using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Domain.Repository;

namespace WebApp.Pages.Order_Pages
{
    [Authorize(Roles ="Customer,Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync(string id = null)
        {

            if (id != null)
            {
                Order = await _unitOfWork.Order.Get().AsQueryable()
                    .Include(o => o.Customer)
                    .Where(c => c.Customer.ApplicationUserId == id && c.IsPaid == true)
                    .ToListAsync();
            }
            else
            {
                Order = await _unitOfWork.Order.Get().AsQueryable()
               .Include(o => o.Customer)
               .ToListAsync();
            }
        }
    }
}
