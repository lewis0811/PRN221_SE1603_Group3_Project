using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages.Services
{
    public class Details2Model : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Details2Model(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Service Service { get; set; }
        public List<LaundryStore> LaundryStores { get; set; }
        public StoreService StoreService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _unitOfWork.Service.Get().AsQueryable()
                .Include(s => s.OrderDetail).FirstOrDefaultAsync(m => m.Id == id);

            if (Service == null)
            {
                return NotFound();
            }

            LaundryStores =  _unitOfWork.LaundryStore.GetAll().ToList();
            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .Include(c => c.LaundryStore).FirstOrDefaultAsync();

            return Page();
        }
    }
}
