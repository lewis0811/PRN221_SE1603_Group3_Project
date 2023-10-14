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

namespace WebApp.Pages.LaundryStore_Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<LaundryStore> LaundryStore { get;set; }

        public async Task OnGetAsync()
        {
            LaundryStore = await _unitOfWork.LaundryStore.Get().AsQueryable()
                .Include(l => l.ApplicationUser).ToListAsync();
        }
    }
}
