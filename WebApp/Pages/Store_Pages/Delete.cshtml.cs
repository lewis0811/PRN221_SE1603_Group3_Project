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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public DeleteModel(DataAccess.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LaundryStore LaundryStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaundryStore = await _context.LaundryStores
                .Include(l => l.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

            if (LaundryStore == null)
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

            LaundryStore = await _context.LaundryStores.FindAsync(id);

            if (LaundryStore != null)
            {
                _context.LaundryStores.Remove(LaundryStore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
