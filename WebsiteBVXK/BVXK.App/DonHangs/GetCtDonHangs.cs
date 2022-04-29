using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.GetCtDonHangs
{
    [Service]
    public class GetCtDonHangs
    {
        ICtDonHangManager _ctDonHangManager;
        public GetCtDonHangs(ICtDonHangManager ctDonHangManager)
        {
            _ctDonHangManager = ctDonHangManager;
        }

        public class CtDonHangViewModel
        {
            public int IdDonHang { get; set; }
            public int IdCtDonHang { get; set; }
            public string SoGhe { get; set; }
        }

    }
}
