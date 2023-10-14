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
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetailsModel(DataAccess.Context.ApplicationDbContext context,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

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
            return Page();
        }
    }
}
