using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages.Store_Pages
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
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
            ViewData["ApplicationUserId"] = new SelectList(_unitOfWork.User.Get(), "Id", "Id");
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

            _unitOfWork.LaundryStore.Update(LaundryStore);

            try
            {
                _unitOfWork.Save();
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
            return _unitOfWork.LaundryStore.Get().Any(e => e.Id == id);
        }
    }
}