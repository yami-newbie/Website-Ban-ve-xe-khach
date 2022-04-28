using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.DeleteDonHang
{
    [Service]
    public class DeleteDonHang
    {
        private IDonHangManager _donHangManager;

        public DeleteDonHang(IDonHangManager donHangManager)
        {
            _donHangManager = donHangManager;
        }

        public Task<int> Do(int id) => _donHangManager.DeleteDonHang(id);
    }
}
