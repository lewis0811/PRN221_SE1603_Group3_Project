using Domain.Entities;
using Domain.Repository;
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

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task OnGetAsync()
        {
            Service = await _unitOfWork.Service.Get().AsQueryable()
                .ToListAsync();
        }
    }
}
