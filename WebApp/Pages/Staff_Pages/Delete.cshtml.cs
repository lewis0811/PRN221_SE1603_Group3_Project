using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;
using AutoMapper;
using WebApp.ViewModels;

namespace WebApp.Pages.Staff_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteModel(DataAccess.Context.ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public StaffVM Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = _mapper.Map<StaffVM>(_context.Staffs
                .Include(s => s.ApplicationUser).FirstOrDefault(m => m.Id == id));

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

            //Staff = _mapper.Map<StaffVM>( _context.Staffs.Find(id));

            if (Staff != null)
            {
                _context.Staffs.Remove(_mapper.Map<Staff>(_context.Staffs.Find(id)));
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
