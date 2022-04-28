using BVXK.Application.FindLichTrinh;
using BVXK.Application.TinhThanh;
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

        public TimVeModel()
        {
            start = "Hà Nội";
            des = "Hồ Chí Minh";
            date = DateTime.Now;
        }

        [BindProperty]
        public string start { get; set; }
        [BindProperty]
        public string des { get; set; }
        [BindProperty]
        public DateTime date { get; set; }
        public void OnPost([FromServices] FindLichTrinh findLichTrinh)
        {
            findLichTrinh.Do(start, des, date);
        }
    }
}
