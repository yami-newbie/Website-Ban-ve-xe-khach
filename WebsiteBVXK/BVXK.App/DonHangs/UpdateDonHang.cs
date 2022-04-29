using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.UpdateDonHang
{
    [Service]
    public class UpdateDonHang
    {
        private IDonHangManager _donHangManager;
        private ILichTrinhManager _lichTrinhManager;
        private ITicketManager _ticketManager;
        public UpdateDonHang(IDonHangManager donHangManager, ILichTrinhManager lichTrinhManager, ITicketManager ticketManager)
        {
            _donHangManager = donHangManager;
            _lichTrinhManager = lichTrinhManager;
            _ticketManager = ticketManager;
        }

        public async Task<Response> Do(Request request)
        {
            var donHang = _donHangManager.GetDonHangById(request.IdDonHang, x => x);

            donHang.IdVeXe = request.IdVeXe;
            donHang.TenKhachHang = request.TenKhachHang;
            donHang.DiemTra = request.DiemTra;
            donHang.DiemDon = request.DiemDon;
            donHang.SoDienThoai = request.SoDienThoai;
            donHang.TinhTrang = request.TinhTrang == "Chưa thanh toán" ? 0 : 1;
            donHang.ThoiGianDon = DateTime.Parse(request.NgayDon + " " + request.GioDon);

            await _donHangManager.UpdateDonHang(donHang);

            var ticket = _ticketManager.GetTicketById(request.IdVeXe, x => x);

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(ticket.IdLichTrinh, y => y);

            return new Response
            {
                IdDonHang = donHang.IdDonHang,
                IdLichTrinh = request.IdLichTrinh,
                IdVeXe = request.IdVeXe,
                IdXe = lichtrinh.IdXe,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiemDon = lichtrinh.NoiXuatPhat,
                DiemTra = lichtrinh.NoiDen,
                TongTien = ticket.GiaVe,
                TinhTrang = request.TinhTrang,
                NgayDon = request.NgayDon,
                GioDon = request.GioDon,
                SoGhe = request.SoGhe,
            };

        }

        public class Request
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
            public string? SoGhe { get; set; }
        }

        public class Response
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
            public string? SoGhe { get; set; }
        }
    }
}
