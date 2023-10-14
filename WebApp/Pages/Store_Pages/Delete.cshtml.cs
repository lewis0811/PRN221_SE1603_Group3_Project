using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;
using WebApp.ViewModels;

namespace WebApp.Pages.Store_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteModel(DataAccess.Context.ApplicationDbContext context, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [BindProperty] public LaundryStoreVM LaundryStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laundryStoreSource = _unitOfWork.LaundryStore.Get().FirstOrDefault(m => m.Id == id);
            LaundryStore = _mapper.Map<LaundryStoreVM>(laundryStoreSource);
            
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

            var laundryStoreEntity = _unitOfWork.LaundryStore.Get().FirstOrDefault(m => m.Id == id);
            LaundryStore = _mapper.Map<LaundryStoreVM>(laundryStoreEntity);
            if (LaundryStore != null)
            {
                _unitOfWork.LaundryStore.Delete(laundryStoreEntity);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}