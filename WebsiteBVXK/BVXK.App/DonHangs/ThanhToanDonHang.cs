using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.ThanhToanDonHang
{
    [Service]
    public class ThanhToanDonHang
    {
        private IDonHangManager _donHangManager;
        public ThanhToanDonHang(IDonHangManager donHangManager)
        {
            _donHangManager = donHangManager;
        }

        public async Task<int> Do(int id)
        {
            var donHang = _donHangManager.GetDonHangById(id, x => x);

            donHang.TinhTrang = 1;

            await _donHangManager.UpdateDonHang(donHang);

            return 1;

        }
    }
}
