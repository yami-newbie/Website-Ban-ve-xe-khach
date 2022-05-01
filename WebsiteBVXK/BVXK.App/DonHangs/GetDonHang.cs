using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.GetDonHang
{
    [Service]
    public class GetDonHang
    {
        private IDonHangManager _donHangManager;
        private ILichTrinhManager _lichTrinhManager;
        private ITicketManager _ticketManager;
        public GetDonHang(IDonHangManager donHangManager, ILichTrinhManager lichTrinhManager, ITicketManager ticketManager)
        {
            _donHangManager = donHangManager;
            _lichTrinhManager = lichTrinhManager;
            _ticketManager = ticketManager;
        }

        public DonHangViewModel Do(int id)
        {
            var x = _donHangManager.GetDonHangById(id, _x => _x);

            var ticket = _ticketManager.GetTicketById(x.IdVeXe, _x => _x);

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(ticket.IdLichTrinh, y => y);

            var xe = lichtrinh.IdXeNavigation;

            var soGhe = xe.LoaiXe == (int)LoaiXe.Ngoi ? 40 : 32;

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
                ChuyenDi = lichtrinh.NoiXuatPhat + " - " + lichtrinh.NoiDen,
                DiemTra = x.DiemTra,
                TongTien = ticket.GiaVe,
                Email = x.Email,
                SoGhes = GetViTri(soGhe, _donHangManager.GetListGheDuocChonByIdDonHang(id)),
                TinhTrang = x.TinhTrang == 0 ? "Chưa thanh toán" : "Đã thanh toán",
            };
        }

        public class DonHangViewModel
        {
            public int IdDonHang { get; set; }
            public int IdVeXe { get; set; }
            public int IdXe { get; set; }
            public int IdLichTrinh { get; set; }
            public string? Email { get; set; }
            public string? ChuyenDi { get; set; }
            public string? TenKhachHang { get; set; }
            public string? SoDienThoai { get; set; }
            public string? NgayDon { get; set; }
            public string? GioDon { get; set; }
            public string? DiemDon { get; set; }
            public string? DiemTra { get; set; }
            public decimal? TongTien { get; set; }
            public string? TinhTrang { get; set; }
            public string? SoGhes { get; set; }
        }

        public string GetViTri(int soLuongGhe, List<int> gheDangChon)
        {

            if (gheDangChon.Count <= 0)
                return "";

            string res = "";

            foreach (int i in gheDangChon)
            {
                var _i = i;
                if (i >= soLuongGhe / 2)
                {
                    _i -= soLuongGhe / 2;
                }

                switch (_i % 3)
                {
                    case 0:
                        res += "A";
                        break;
                    case 1:
                        res += "B";
                        break;
                    default:
                        res += "C";
                        break;
                }

                var y = _i / 3;

                if (i < soLuongGhe / 2)
                {
                    res += (y * 2 + 1).ToString();
                }
                else
                {
                    res += (y * 2 + 2).ToString();
                }

                res += ", ";
            }

            return res.Substring(0, res.Length - 2);
        }
    }
}
