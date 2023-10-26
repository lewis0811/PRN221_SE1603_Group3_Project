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

namespace WebApp.Pages.Customer_Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _unitOfWork.Customer.Get().AsQueryable()
                .Include(c => c.ApplicationUser).FirstOrDefaultAsync(m => m.Id.ToString() == id || m.ApplicationUserId == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
