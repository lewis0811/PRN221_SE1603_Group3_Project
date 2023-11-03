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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages.Store_Pages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Context.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(DataAccess.Context.ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IList<LaundryStore> LaundryStore { get;set; }

        public async Task OnGetAsync()
        {
            LaundryStore =  _unitOfWork.LaundryStore.Get().AsQueryable().Include(l=> l.ApplicationUser).ToList();
        }
    }
}
