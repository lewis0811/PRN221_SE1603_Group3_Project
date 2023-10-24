using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGet()
        {
            RegisterViewModel = new();
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                // Create roles
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
                await _roleManager.CreateAsync(new IdentityRole("LaundryStore"));
                await _roleManager.CreateAsync(new IdentityRole("Staff"));
            }

            List<SelectListItem> listItems = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = "Admin",
                    Text = "Admin"
                },
                new SelectListItem()
                {
                    Value = "Customer",
                    Text = "Customer"
                },
                new SelectListItem()
                {
                    Value = "LaundryStore",
                    Text = "LaundryStore"
                },
                new SelectListItem()
                {
                    Value = "Staff",
                    Text = "Staff"
                }
            };

            RegisterViewModel.RoleList = listItems;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = RegisterViewModel.Email,
                    Email = RegisterViewModel.Email,
                    Name = RegisterViewModel.Name
                };

                var result = await _userManager.CreateAsync(user, RegisterViewModel.Password);

                if (result.Succeeded)
                {
                    if (RegisterViewModel.RoleSelected != null && RegisterViewModel.RoleSelected.Length > 0 && RegisterViewModel.RoleSelected == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else if (RegisterViewModel.RoleSelected == "Staff")
                    {
                        await _userManager.AddToRoleAsync(user, "Staff");
                        _unitOfWork.Staff.Add(new Staff() {
                            Name = RegisterViewModel.Name,
                            Address = "No edit yet",
                            Age = 18,
                            JobPosition = 0,
                            ApplicationUserId = user.Id
                        });
                    }
                    else if (RegisterViewModel.RoleSelected == "Customer")
                    {
                        await _userManager.AddToRoleAsync(user, "Customer");
                        _unitOfWork.Customer.Add(new Customer()
                        {
                            ApplicationUserId = user.Id,
                            Name = RegisterViewModel.Name,
                            Address = "No edit yet", 
                        });
                    }
                    else if (RegisterViewModel.RoleSelected == "LaundryStore")
                    {
                        await _userManager.AddToRoleAsync(user, "LaundryStore");
                        _unitOfWork.LandryStore.Add(new LaundryStore()
                        {
                            ApplicationUserId= user.Id,
                            Name = RegisterViewModel.Name,
                            Address = "No edit yet",
                            Capacity = 5,
                            Status = true,
                        });
                    }
                    _unitOfWork.Save();
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }
                else
                {
                    AddErrors(result);
                }
            }

            List<SelectListItem> listItems = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = "Admin",
                    Text = "Admin"
                },
                new SelectListItem()
                {
                    Value = "User",
                    Text = "User"
                }
            };

            RegisterViewModel.RoleList = listItems;
            return Page();
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