using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        private readonly ILogger<IndexModel> _logger;

        public IList<Service> Service { get; set; }
        public IList<OrderDetail> OrderDetails{ get; set; }
        public IList<Order> Orders { get; set; }
        [BindProperty]
        public Order Order { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task OnGetAsync()
        {
            Service = await _unitOfWork.Service.Get().AsQueryable()
                .ToListAsync();

            OrderDetails = await _unitOfWork.OrderDetail.Get().AsQueryable()
                .Include(c => c.Order)
                .Where(c => c.Order.OrderStatus != Domain.Enums.OrderStatus.Washed
                || c.Order.OrderStatus != Domain.Enums.OrderStatus.Finished)
                .ToListAsync();

            await ListOrderByRole();

        }

        private async Task ListOrderByRole()
        {
            if (User.IsInRole("LaundryStore"))
            {
                Orders = await _unitOfWork.Order.Get().AsQueryable()
                .Where(c => c.IsPaid == true &&
                c.OrderStatus == Domain.Enums.OrderStatus.Washing)
                .ToListAsync();
            }
            else
            {
                Orders = await _unitOfWork.Order.Get().AsQueryable()
                .Where(c => c.IsPaid == true
                && c.OrderStatus != Domain.Enums.OrderStatus.Washed
                || c.OrderStatus == Domain.Enums.OrderStatus.Finished)
                .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostSaveAsync(int Id)
        {
            Orders = await _unitOfWork.Order.Get().AsQueryable()
                .Where(c => c.IsPaid == true
                && c.OrderStatus == Domain.Enums.OrderStatus.Washing
                || c.OrderStatus != Domain.Enums.OrderStatus.Finished)
                .ToListAsync();

            var entity = await _unitOfWork.Order.Get().AsQueryable()
                .FirstOrDefaultAsync(c => c.Id == Id);
            if (entity != null)
            {
                entity.OrderStatus = Order.OrderStatus;
                _unitOfWork.Order.Update(entity);
                _unitOfWork.Save();
            }
            return Page();
        }
    }
}
