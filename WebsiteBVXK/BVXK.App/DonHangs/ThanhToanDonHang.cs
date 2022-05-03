using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
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
        private IThongKeManager _thongKeManager;
        private ITicketManager _ticketManager;
        private ILichTrinhManager _lichTrinhManager;
        private IXeManager _xeManager;
        public ThanhToanDonHang(IDonHangManager donHangManager, IThongKeManager thongKeManager, ITicketManager ticketManager, ILichTrinhManager lichTrinhManager, IXeManager xeManager)
        {
            _donHangManager = donHangManager;
            _thongKeManager = thongKeManager;
            _ticketManager = ticketManager;
            _lichTrinhManager = lichTrinhManager;
            _xeManager = xeManager;
        }

        public async Task<int> Do(int id)
        {
            var donHang = _donHangManager.GetDonHangById(id, x => x);

            donHang.TinhTrang = 1;

            await _donHangManager.UpdateDonHang(donHang);

            var ticket = _ticketManager.GetTicketById(donHang.IdVeXe, x => x);

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(ticket.IdLichTrinh, x => x);

            var xe = _xeManager.GetXeById(lichtrinh.IdXe, x => x);

            var thongKe = new ThongKe
            {
                IdVe = donHang.IdVeXe,
                NgayDat = DateTime.Now,
                LoaiVe = xe.LoaiXe,
                GiaVe = ticket.GiaVe,
                SoLuong = donHang.SoLuong,
            };

            await _thongKeManager.CreateThongKe(thongKe);

            return 1;

        }
    }
}
