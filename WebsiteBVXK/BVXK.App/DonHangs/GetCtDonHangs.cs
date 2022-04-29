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
        public IEnumerable<CtDonHangViewModel> Do() =>
            _ctDonHangManager.GetCtDonHang(x =>
            {
                return new CtDonHangViewModel
                {
                    IdCtDonHang = x.IdCtdonHang,
                    IdDonHang = x.IdDonHang,
                    SoGhe = x.SoGhe
                };
            });

        public class CtDonHangViewModel
        {
            public int IdDonHang { get; set; }
            public int IdCtDonHang { get; set; }
            public int SoGhe { get; set; }
        }

    }
}
