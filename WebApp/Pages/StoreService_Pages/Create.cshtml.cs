using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Pages.StoreService_Pages
{
    public class CreateModel : PageModel
    {

        public LaundryStore LaundryStore { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGet(string? id = null)
        {
            ViewData["LaundryStoreName"] = new SelectList(_unitOfWork.LaundryStore.Get(), "Id", "Name");
            ViewData["ServiceId"] = new SelectList(_unitOfWork.Service.Get(), "Id", "Name");
            LaundryStore = await _unitOfWork.LaundryStore.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.Id.ToString() == id);
            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.LaundryStoreId.ToString() == id);
            return Page();
        }

        [BindProperty]
        public StoreService StoreService { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string id = null)
        {
            var storeId = id;
            if (!ModelState.IsValid)
            {
                ViewData["LaundryStoreName"] = new SelectList(_unitOfWork.LaundryStore.Get(), "Id", "Name");
                ViewData["ServiceId"] = new SelectList(_unitOfWork.Service.Get(), "Id", "Name");
                LaundryStore = await _unitOfWork.LaundryStore.Get().AsQueryable()
                    .FirstOrDefaultAsync(c => c.Id.ToString() == id);
                
                return Page();
            }
            var newStoreService = new StoreService();
            newStoreService = StoreService;
            newStoreService.LaundryStoreId = int.Parse(id);
            //StoreService = _unitOfWork.StoreService.Get().AsQueryable().Include(c => c.LaundryStore)
            //    .FirstOrDefault(c => c.Id == StoreService.LaundryStoreId);

            _unitOfWork.StoreService.Add(newStoreService);
            _unitOfWork.Save();

            return RedirectToPage("/StoreService_Pages/Index", routeValues: new { storeId });
        }
    }
}
