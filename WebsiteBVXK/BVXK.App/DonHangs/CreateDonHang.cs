using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.CreateDonHang
{
    [Service]
    public class CreateDonHang
    {
        private IDonHangManager _donHangManager;

        public CreateDonHang(IDonHangManager donHangManager)
        {
            _donHangManager = donHangManager;
        }

        public async Task<Response> Do(Request request)
        {
            var donHang = new DonHang
            {
                IdLichTrinh = request.IdLichTrinh,
                IdVeXe = request.IdVeXe,
                IdXe = request.IdXe,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiemDon = request.DiemDon,
                DiemTra = request.DiemTra,
                TongTien = request.TongTien,
                TinhTrang = request.TinhTrang == "Chưa thanh toán" ? 0 : 1,
                ThoiGianDon = DateTime.Parse(request.NgayDon + " " + request.GioDon ),
            };

            if (await _donHangManager.CreateDonHang(donHang) <= 0)
            {
                throw new Exception("Failed to create donHang");
            }


            return new Response
            {
                IdDonHang = donHang.IdDonHang,
                IdLichTrinh = request.IdLichTrinh,
                IdVeXe = request.IdVeXe,
                IdXe = request.IdXe,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiemDon = request.DiemDon,
                DiemTra = request.DiemTra,
                TongTien = request.TongTien,
                TinhTrang = request.TinhTrang,
                NgayDon = request.NgayDon,
                GioDon = request.GioDon,
            };
        }

        public class Request
        {
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

        }
    }
}
