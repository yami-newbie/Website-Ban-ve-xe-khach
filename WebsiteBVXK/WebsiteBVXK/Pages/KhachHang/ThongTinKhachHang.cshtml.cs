using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BVXK.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVXK.Domain.Models;
using BVXK.Domain.Infrastructure;

namespace WebsiteBVXK.Pages.KhachHang
{
    public class ThongTinKhachHangModel : PageModel
    {
        private ISessionManager _sessionManager;

        public ThongTinKhachHangModel(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        [BindProperty]
        public string tenkhach { get; set; }
        [BindProperty]
        public string sdt { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string cmnd { get; set; }
        [BindProperty]
        public string ghichu { get; set; }
         
        public IActionResult OnPost([FromServices] CustomerDetail customerDetail)
        {
            Customer customer = new Customer(tenkhach, sdt, email, cmnd);
            _sessionManager.AddCustomerInformation(customer);

            return RedirectToPage("/KhachHang/XacNhanThongTin");
        }
    }
}
