using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;
using WebApp.ViewModels;

namespace WebApp.Pages.Staff_Pages
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateModel(DataAccess.Context.ApplicationDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public StaffVM Staff { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var staffEntity = _mapper.Map<Staff>(Staff);
            if (staffEntity == null)
            {
               throw new Exception(); 
            }
            _unitOfWork.Staff.Add(staffEntity);
            return RedirectToPage("./Index");
        }
    }
}
