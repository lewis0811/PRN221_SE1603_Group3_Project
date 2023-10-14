using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Pages.LaundryStore_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [BindProperty]
        public LaundryStoreVM LaundryStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaundryStore = _mapper.Map<LaundryStoreVM>(_unitOfWork.LaundryStore.Get().AsQueryable()
                .Include(l => l.ApplicationUser).FirstOrDefault(m => m.Id == id));

            if (LaundryStore == null)
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

            LaundryStore = _mapper.Map<LaundryStoreVM>(_unitOfWork.LaundryStore.Get().Where(c => c.Id == id).FirstOrDefault());

            if (LaundryStore != null)
            {
                _unitOfWork.LaundryStore.Delete(_mapper.Map<LaundryStore>(LaundryStore));
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}