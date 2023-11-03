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
using Domain.Repository;

namespace WebApp.Pages.StoreService_Pages
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public StoreService StoreService { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .Include(s => s.LaundryStore)
                .Include(s => s.Service).FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (StoreService == null)
            {
                return NotFound();
            }
           ViewData["LaundryStoreId"] = new SelectList(_unitOfWork.LaundryStore.Get(), "Id", "Name");
           ViewData["ServiceId"] = new SelectList(_unitOfWork.Service.Get(), "Id", "Name");
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

            _unitOfWork.StoreService.Update(StoreService);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreServiceExists(StoreService.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index/", routeValues: new {storeId = StoreService.LaundryStoreId });
        }

        private bool StoreServiceExists(int id)
        {
            return _unitOfWork.StoreService.Get().Any(e => e.Id == id);
        }
    }
}
