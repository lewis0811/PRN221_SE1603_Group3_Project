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

namespace WebApp.Pages.Store_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public LaundryStore LaundryStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaundryStore = await _unitOfWork.LaundryStore.Get().AsQueryable()
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

            LaundryStore = _unitOfWork.LaundryStore.Get().FirstOrDefault(c => c.Id == id);

            if (LaundryStore != null)
            {
                _unitOfWork.LaundryStore.Delete(LaundryStore);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
