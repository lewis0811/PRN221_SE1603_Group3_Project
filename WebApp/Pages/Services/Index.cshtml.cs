using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages.Services
{
    [Authorize(Roles = "Customer,Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Service> Service { get;set; }

        public async Task OnGetAsync()
        {
            Service = await _unitOfWork.Service.Get().AsQueryable()
                .ToListAsync();
        }
    }
}
