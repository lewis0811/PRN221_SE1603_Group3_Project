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
using DataAccess.Implementation;

namespace WebApp.Pages.StoreService_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public StoreService StoreService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .Include(s => s.LaundryStore)
                .Include(s => s.Service).FirstOrDefaultAsync(m => m.Id == id);

            if (StoreService == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            var storeId = 0;
            if (id == null)
            {
                return NotFound();
            }

            StoreService = await _unitOfWork.StoreService.Get().AsQueryable().FirstOrDefaultAsync(s => s.Id.ToString() == id);
            
            if (StoreService != null)
            {
                 storeId = StoreService.LaundryStoreId;
                _unitOfWork.StoreService.Delete(StoreService);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index/", routeValues: new { storeId });
        }
    }
}
