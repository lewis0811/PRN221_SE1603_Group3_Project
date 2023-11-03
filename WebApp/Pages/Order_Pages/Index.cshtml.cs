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

namespace WebApp.Pages.Order_Pages
{
    [Authorize(Roles ="Customer,Admin")]
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public IndexModel(DataAccess.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync(string id = null)
        {

            if (Order != null)
            {
                Order = await _context.Orders
                    .Include(o => o.Customer)
                    .Where(c => c.Customer.ApplicationUserId == id && c.IsPaid == true)
                    .ToListAsync();
            }
            else
            {
                Order = await _context.Orders
               .Include(o => o.Customer)
               .ToListAsync();
            }
        }
    }
}
