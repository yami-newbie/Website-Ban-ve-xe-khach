using BVXK.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        IAccountManager _accountManager;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config, IAccountManager accountManager)
        {
            _logger = logger;
            _config = config;
            _accountManager = accountManager;
        }

        public IActionResult OnGet()
        {
            if (_accountManager.GetIsLogin())
            {
                return RedirectToPage("/Admin/TrangQuanLy");
            }
            return Page();
        }

        public void OnGetLogout()
        {
            _accountManager.SetIsLogin(false);

            //return RedirectToPage("Index");
        }
    }
}
