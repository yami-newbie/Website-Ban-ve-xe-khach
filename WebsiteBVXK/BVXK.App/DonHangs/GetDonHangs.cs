using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
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

        public GetDonHangs(IDonHangManager donHangManager)
        {
            _donHangManager = donHangManager;
        }

        public IEnumerable<DonHangViewModel> Do() =>
            _donHangManager.GetDonHangs(x => {
                return new DonHangViewModel
                {
                    IdDonHang = x.IdDonHang,
                    IdVeXe = x.IdVeXe,
                    IdLichTrinh = x.IdLichTrinh,
                    IdXe = x.IdXe,
                    TenKhachHang = x.TenKhachHang,
                    SoDienThoai = x.SoDienThoai,
                    GioDon = x.ThoiGianDon.GetValueOrDefault().ToString("hh:mm"),
                    NgayDon = x.ThoiGianDon.GetValueOrDefault().ToString("yyyy-MM-dd"),
                    DiemDon = x.DiemDon,
                    DiemTra = x.DiemTra,
                    TongTien = x.TongTien,
                    TinhTrang = x.TinhTrang == 0 ? "Chưa thanh toán" : "Đã thanh toán"
                };
            });

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
