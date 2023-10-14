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

namespace WebApp.Pages.StoreService_Pages
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
        ViewData["LaundryStoreId"] = new SelectList(_unitOfWork.LaundryStore.Get(), "Id", "Address");
        ViewData["ServiceId"] = new SelectList(_unitOfWork.Service.Get(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public StoreService StoreService { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.StoreService.Add(StoreService);
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}
