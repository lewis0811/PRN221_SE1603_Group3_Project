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

namespace WebApp.Pages.Staff_Pages
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

            var staffEntity = _mapper.Map<Staff>(Staff);
            _unitOfWork.Staff.Update(staffEntity);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(Staff.Id))
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

        private bool StaffExists(int id)
        {
            return _unitOfWork.Staff.Get().Any(e => e.Id == id);
        }
    }
}