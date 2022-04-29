using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages.KhachHang
{
    public class XacNhanThongTinModel : PageModel
    {
        public Customer customer { get; set; }
        public int seats { get; set; }
        public ICustomerManager _customerManager;
        public IDonHangManager _donHangManager;
        public XacNhanThongTinModel (ICustomerManager customerManager, IDonHangManager donHangManager)
        {
            _customerManager = customerManager;
            _donHangManager = donHangManager;
            seats = 0;
            customer = _customerManager.GetResult();
        }
    }
}
