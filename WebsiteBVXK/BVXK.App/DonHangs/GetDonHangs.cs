using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.GetDonHangs
{
    [Service]
    public class GetDonHangs
    {
        private IDonHangManager _donHangManager;
        private ILichTrinhManager _lichTrinhManager;
        private ITicketManager _ticketManager;
        public GetDonHangs(IDonHangManager donHangManager, ILichTrinhManager lichTrinhManager, ITicketManager ticketManager)
        {
            _donHangManager = donHangManager;
            _lichTrinhManager = lichTrinhManager;
            _ticketManager = ticketManager;
        }

        public IEnumerable<DonHangViewModel> Do()
        {
            var res = _donHangManager.GetDonHangs(x => x);
            return res.Select(x => getData(x));
        }
        private DonHangViewModel getData(DonHang x)
        {
            var ticket = x.IdVeXeNavigation; //_ticketManager.GetTicketById(x.IdVeXe, x => x);

            var lichtrinh = ticket.IdLichTrinhNavigation; //_lichTrinhManager.GetLichTrinhById(ticket.IdLichTrinh, y => y);

            return new DonHangViewModel
            {
                IdDonHang = x.IdDonHang,
                IdVeXe = x.IdVeXe,
                IdLichTrinh = ticket.IdLichTrinh,
                IdXe = lichtrinh.IdXe,
                TenKhachHang = x.TenKhachHang,
                SoDienThoai = x.SoDienThoai,
                GioDon = x.ThoiGianDon.GetValueOrDefault().ToString("hh:mm"),
                NgayDon = x.ThoiGianDon.GetValueOrDefault().ToString("yyyy-MM-dd"),
                DiemDon = x.DiemDon,
                DiemTra = x.DiemTra,
                TongTien = ticket.GiaVe * x.SoLuong,
                TinhTrang = x.TinhTrang == 0 ? "Chưa thanh toán" : "Đã thanh toán",
            };
        }
        public class DonHangViewModel
        {
            public int IdDonHang { get; set; }
            public int IdVeXe { get; set; }
            public int IdXe { get; set; }
            public int IdLichTrinh { get; set; }
            public string? TenKhachHang { get; set; }
            public string? SoDienThoai { get; set; }
            public string? NgayDon { get; set; }
            public string? GioDon { get; set; }
            public string? DiemDon { get; set; }
            public string? DiemTra { get; set; }
            public decimal? TongTien { get; set; }
            public string? TinhTrang { get; set; }
        }
    }
}
