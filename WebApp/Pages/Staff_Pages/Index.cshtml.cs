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

namespace WebApp.Pages.Staff_Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        

        public IndexModel(DataAccess.Context.ApplicationDbContext context,IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IList<Staff> Staff { get;set; }

        public async Task OnGetAsync()
        {
            Staff = await _unitOfWork.Staff.Get().AsQueryable().Include(s=>s.ApplicationUser).ToListAsync();
        }
    }
}
