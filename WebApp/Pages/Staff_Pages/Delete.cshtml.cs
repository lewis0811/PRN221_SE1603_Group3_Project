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

namespace WebApp.Pages.Staff_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteModel(DataAccess.Context.ApplicationDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [BindProperty] public StaffVM Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffEntity = _unitOfWork.Staff.Get().AsQueryable().Include(s => s.ApplicationUser)
                .FirstOrDefault(m => m.Id == id);
            Staff = _mapper.Map<StaffVM>(staffEntity);
            if (Staff == null)
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

            var staffEntity = _unitOfWork.Staff.Get().FirstOrDefault(m => m.Id == id);
            Staff = _mapper.Map<StaffVM>(staffEntity);

            if (Staff != null)
            {
                _unitOfWork.Staff.Delete(staffEntity);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}