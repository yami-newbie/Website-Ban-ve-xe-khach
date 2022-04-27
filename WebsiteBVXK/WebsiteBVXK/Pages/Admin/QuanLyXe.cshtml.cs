using BVXK.Application.GetXes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages.Admin
{
    public class QuanLyXeModel : PageModel
    {
        public IEnumerable<GetXes.XeViewModel> Xes { get; set; }
        public void OnGet([FromServices] GetXes getXes)
        {
            Xes = getXes.Do();
        }
    }
}
