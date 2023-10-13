using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;

namespace WebApp.Pages.Staff_Pages
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public DetailsModel(DataAccess.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public Staff Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = await _context.Staffs
                .Include(s => s.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Staff == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
