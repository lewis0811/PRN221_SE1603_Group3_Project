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
using WebApp.ViewModels;
using AutoMapper;

namespace WebApp.Pages.LaundryStore_Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetailsModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
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

            LaundryStore = _mapper.Map<LaundryStoreVM>(_unitOfWork.LaundryStore.Get().AsQueryable()
                .Include(l => l.ApplicationUser).FirstOrDefault(m => m.Id == id));

            if (LaundryStore == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
