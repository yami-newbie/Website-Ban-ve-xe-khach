using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages.KhachHang
{
    public class ThongTinKhachHangModel : PageModel
    {
        public IActionResult OnPost()
        {
            return RedirectToPage("/KhachHang/XacNhanThongTin");
        }
    }
}
