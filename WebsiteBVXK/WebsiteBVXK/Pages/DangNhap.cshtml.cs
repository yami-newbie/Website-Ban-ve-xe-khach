using BVXK.Application.SignIn;
using BVXK.Application.SignUp;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages
{
    public class DangNhapModel : PageModel
    {
        private IAccountManager _accountManager;

        public DangNhapModel(IAccountManager accountManager)
        {
            _accountManager = accountManager;
            isError = false;
        }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        [BindProperty]
        public bool isError { get; set; }

        public IActionResult OnGet()
        {
            if (_accountManager.GetIsLogin())
            {
                return RedirectToPage("/Admin/TrangQuanLy");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(
            [FromServices] SignIn signIn,
            [FromServices] SignUp signUp)
        {
            if(!String.IsNullOrEmpty(Input.Username) && !String.IsNullOrEmpty(Input.Password))
            {
                bool result = signIn.Do(Input.Username, Input.Password);

                if (result)
                {
                    _accountManager.SetIsLogin(true);
                    return RedirectToPage("/Admin/TrangQuanLy");
                }
                else
                {
                    isError = true;
                    await signUp.Do(new SignUp.Request
                    {
                        Username = "admin",
                        Password = "admin"
                    });
                }
            }

            return Page();
        }

        public class LoginViewModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
