using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;
using WebApp.ViewModels;

namespace WebApp.Pages.Store_Pages
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditModel(DataAccess.Context.ApplicationDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [BindProperty]
        public LaundryStoreVM LaundryStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laundryStoreEntity = _unitOfWork.LaundryStore.Get().AsQueryable().Include(s=>s.ApplicationUser).FirstOrDefault(m => m.Id == id);
            LaundryStore = _mapper.Map<LaundryStoreVM>(laundryStoreEntity);
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

            var laundryStoreEntity = _mapper.Map<LaundryStore>(LaundryStore);
            _unitOfWork.LaundryStore.Update(laundryStoreEntity);
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
