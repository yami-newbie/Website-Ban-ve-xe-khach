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
        private ILichTrinhManager _lichTrinhManager;
        private ITicketManager _ticketManager;
        private ICtDonHangManager _ctdonHangManager;
        private IXeManager _xeManager;
        public CreateDonHang(IDonHangManager donHangManager, ILichTrinhManager lichTrinhManager, ITicketManager ticketManager, ICtDonHangManager ctdonHangManager, IXeManager xeManager)
        {
            _donHangManager = donHangManager;
            _lichTrinhManager = lichTrinhManager;
            _ticketManager = ticketManager;
            _ctdonHangManager = ctdonHangManager;
            _xeManager = xeManager;
        }

        public async Task<Response> Do(Request request)
        {
            var donHang = new DonHang
            {
                IdVeXe = request.IdVeXe,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiemDon = request.DiemDon,
                DiemTra = request.DiemTra,
                TinhTrang = request.TinhTrang == "Chưa thanh toán" ? 0 : 1,
                ThoiGianDon = DateTime.Parse(request.NgayDon + " " + request.GioDon ),
                Email = request.Email,
                Cmnd = request.Cmnd,
                GhiChu = request.GhiChu,
                SoLuong = request.SoLuong,
            };

            if (await _donHangManager.CreateDonHang(donHang) <= 0)
            {
                throw new Exception("Failed to create donHang");
            }

            if (request.SoGhes.Count > 0)
            {
                var ghes = request.SoGhes;
                ghes.ForEach(g =>
                {
                    var ct = new CtDonHang
                    {
                        IdDonHang = request.IdDonHang,
                        SoGhe = g,
                    };
                    _ctdonHangManager.CreateCtDonHang(ct).Wait();
                });
            }

            var ticket = _ticketManager.GetTicketById(donHang.IdVeXe, x => x);

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(ticket.IdLichTrinh, y => y);

            var loaixe = _xeManager.GetXeById(lichtrinh.IdXe, x => x.LoaiXe);

            var soghe = 0;

            if(loaixe == (int)LoaiXe.Ngoi)
            {
                soghe = 40;
            }
            else
            {
                soghe = 32;
            }

            var sovedadat = _ctdonHangManager.GetCtDonHangByIdDonHang(donHang.IdDonHang, x => x );

            if(sovedadat.Count() + request.SoGhes.Count == soghe)
            {
                _ticketManager.UpdateTicket(new VeXe
                {
                    IdVe = ticket.IdVe,
                    IdLichTrinh = ticket.IdLichTrinh,
                    GiaVe = ticket.GiaVe,
                    TinhTrang = 1,
                    LoaiVe = ticket.LoaiVe,
                }).Wait();
            }

            return new Response
            {
                IdDonHang = donHang.IdDonHang,
                IdLichTrinh = ticket.IdLichTrinh,
                IdVeXe = request.IdVeXe,
                IdXe = lichtrinh.IdXe,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiemDon = lichtrinh.NoiXuatPhat,
                DiemTra = lichtrinh.NoiDen,
                TongTien = ticket.GiaVe * request.SoLuong,
                TinhTrang = request.TinhTrang,
                NgayDon = request.NgayDon,
                GioDon = request.GioDon,
            };
        }

        public class Request
        {
            public int IdDonHang { get; set; }
            public int IdVeXe { get; set; }
            public string? TenKhachHang { get; set; }
            public string? SoDienThoai { get; set; }
            public string? NgayDon { get; set; }
            public string? GioDon { get; set; }
            public string? TinhTrang { get; set; }
            public string? DiemDon { get; set; }
            public string? DiemTra { get; set; }
            public string? Email { get; set; }
            public string? Cmnd { get; set; }
            public int? SoLuong { get; set; }
            public string? GhiChu { get; set; }
            public List<int>? SoGhes { get; set; }
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
