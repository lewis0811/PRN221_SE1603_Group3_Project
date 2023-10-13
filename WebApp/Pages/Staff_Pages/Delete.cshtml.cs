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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public DeleteModel(DataAccess.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = await _context.Staffs.FindAsync(id);

            if (Staff != null)
            {
                _context.Staffs.Remove(Staff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
