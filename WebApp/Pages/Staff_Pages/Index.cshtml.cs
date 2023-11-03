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

namespace WebApp.Pages.Staff_Pages
{
    [Authorize(Roles =("Admin,Staff"))]
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public IndexModel(DataAccess.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get;set; }

        public async Task OnGetAsync()
        {
            Staff = await _context.Staffs
                .Include(s => s.ApplicationUser).ToListAsync();
        }
    }
}
