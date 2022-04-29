using BVXK.Application.FindLichTrinh;
using BVXK.Application.TinhThanh;
using BVXK.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace WebsiteBVXK.Pages
{
    public class TimVeModel : PageModel
    {
        public List<string> tinhtp = TinhThanh.tinhs.ToList();
        private ILichTrinhManager _lichTrinhManager;

        public TimVeModel(ILichTrinhManager lichTrinhManager)
        {
            _lichTrinhManager = lichTrinhManager;
            timVe = new TimVe();

            timVe.start = "Hà Nội";
            timVe.des = "Hồ Chí Minh";
            timVe.date = DateTime.Now;
        }
        [BindProperty]
        public TimVe timVe { get; set; }

        public class TimVe
        {
            public string start { get; set; }
            public string des { get; set; }
            public DateTime date { get; set; }
        }

        public IActionResult OnPost([FromServices] FindLichTrinh findLichTrinh)
        {
            var res = findLichTrinh.Do(timVe.start, timVe.des, timVe.date);

            if(res.Count() > 0)
            {
                return RedirectToPage("/KhachHang/ThongTinVe");
            }

            return Page();
        }
    }
}
