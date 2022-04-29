using BVXK.Application.GetDonHangs;
using BVXK.Application.GetXes;
using BVXK.Application.GetCtDonHangs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages.KhachHang
{
    public class GiuongModel : PageModel
    {
        public IEnumerable<GetXes.XeViewModel> Xes { get; set; }
        public IEnumerable<GetDonHangs.DonHangViewModel> DonHangs { get; set; }
        public IEnumerable<GetCtDonHangs> CtDonHang { get; set; }
        public void OnGet([FromServices] GetXes getXes)
        {
            Xes = getXes.Do();
        }
    }
}
