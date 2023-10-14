using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;

namespace WebApp.Pages.Store_Pages
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public EditModel(DataAccess.Context.ApplicationDbContext context)
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
           ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LaundryStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaundryStoreExists(LaundryStore.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LaundryStoreExists(int id)
        {
            return _context.LaundryStores.Any(e => e.Id == id);
        }
    }
}
