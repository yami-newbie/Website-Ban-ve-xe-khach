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
        public List<string> diemDi = TinhThanh.diemDi.ToList();
        public List<string> diemDen = TinhThanh.diemDen.ToList();
        private ISessionManager _sessionManager;
        private ILichTrinhManager _lichTrinhManager;
        public TimVeModel(ISessionManager sessionManager, ILichTrinhManager lichTrinhManager)
        {
            timVe = new TimVe();

            timVe.start = "Hà Nội";
            timVe.des = "Hồ Chí Minh";
            timVe.date = DateTime.Now;
            _sessionManager = sessionManager;
            _lichTrinhManager = lichTrinhManager;
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
            var res = _lichTrinhManager.FindLichTrinh(timVe.start, timVe.des, timVe.date, x => x); //findLichTrinh.Do(timVe.start, timVe.des, timVe.date);

            if(res.Count() > 0)
            {
                _sessionManager.AddLichResult(res.ToList());
            }
            return RedirectToPage("/KhachHang/ThongTinVe");

            //return Page();
        }
    }
}
