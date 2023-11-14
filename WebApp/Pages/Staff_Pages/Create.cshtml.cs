using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Identity;
using WebApp.ViewModels;

namespace WebApp.Pages.Staff_Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
        //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Staff Staff { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new ApplicationUser
            {
                UserName = RegisterViewModel.Email,
                Email = RegisterViewModel.Email,
                Name = RegisterViewModel.Name
            };

            var result = await _userManager.CreateAsync(user, RegisterViewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Staff");
                _unitOfWork.Staff.Add(new Staff()
                {
                    ApplicationUserId = user.Id,
                    Name = RegisterViewModel.Name,
                    Age = Staff.Age,
                    JobPosition = Domain.Enums.JobPosition.Collector,
                    Address = Staff.Address,
                });
                _unitOfWork.Save();
                return RedirectToPage("./Index");
            }
            else
            {
                AddErrors(result);
            }

            return RedirectToPage("./Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
