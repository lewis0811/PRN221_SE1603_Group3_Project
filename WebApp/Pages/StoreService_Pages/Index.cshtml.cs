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

namespace WebApp.Pages.StoreService_Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<StoreService> StoreService { get;set; }

        public async Task OnGetAsync(string storeId = null )
        {
            ViewData["id"] = storeId;
            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .Include(s => s.LaundryStore)
                .Include(s => s.Service)
                .Where(c => c.LaundryStoreId.ToString() == storeId)
                .ToListAsync();
        }
    }
}
