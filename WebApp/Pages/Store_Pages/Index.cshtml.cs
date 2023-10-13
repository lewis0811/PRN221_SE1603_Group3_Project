using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;

namespace WebApp.Pages.Store_Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public IndexModel(DataAccess.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LaundryStore> LaundryStore { get;set; }

        public async Task OnGetAsync()
        {
            LaundryStore = await _context.LaundryStores
                .Include(l => l.ApplicationUser).ToListAsync();
        }
    }
}
