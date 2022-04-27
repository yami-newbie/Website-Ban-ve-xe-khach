using BVXK.Application.TinhThanh;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages
{
    public class QuanLyLichTrinhModel : PageModel
    {
        public List<string> tinhtp = TinhThanh.tinhs.ToList();
    }
}
