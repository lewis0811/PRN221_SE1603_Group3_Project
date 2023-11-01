using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public ResetPasswordViewModel model { get; set; }
        private readonly UserManager<IdentityUser> _userManager;

        public ResetPasswordModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult OnGet(string code = null, string userId = null)
        {
            if(code == null || userId == null) 
            {
                return RedirectToPage("/Index");
            }
            ViewData["UserId"] = userId;
            ViewData["Code"] = code;
            return Page();
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user == null)
                {
                    return Page();
                }
                
                var result = await _userManager.ResetPasswordAsync(user , model.Code,model.Password);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Account/ResetPasswordConfirmation");
                    
                }
                AddError(result);
            }

            var route = new
            {
                code = ViewData["code"].ToString(),
                userId = ViewData["UserId"].ToString()
            };
            return new RedirectToPageResult("/Account/ResetPassword", route);
        }

        private void AddError(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

        }
    }
}
