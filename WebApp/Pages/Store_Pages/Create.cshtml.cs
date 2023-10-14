using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Context;
using Domain.Entities;

namespace WebApp.Pages.Store_Pages
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;

        public CreateModel(DataAccess.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public LaundryStore LaundryStore { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LaundryStores.Add(LaundryStore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
