using BVXK.Application.CreateDonHang;
using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBVXK.Pages.KhachHang
{
    public class XacNhanThongTinModel : PageModel
    {
        public Customer customer { get; set; }
        public List<int> seats { get; set; }
        public string seat { get; set; }
        public int tongtien { get; set; }
        public string loaiXe { get; set; }
        public string chuyen { get; set; }
        public string ngayDi { get; set; }
        public string gioDi { get; set; }
        public string noiDon { get; set; }
        public string noiTra { get; set; }
        public CreateDonHang.Request request { get; set; }
        public DonHang donHang { get; set; }
        public ThongKe thongKe { get; set; }
        public ICustomerManager _customerManager;
        public IDonHangManager _donHangManager;
        public ITicketManager _ticketManager;
        public IXeManager _xeManager;
        public ILichTrinhManager _lichTrinhManager;
        public IThongKeManager _thongKeManager;
        public ICtDonHangManager _ctdonHangManager;

        public XacNhanThongTinModel(
            ICustomerManager customerManager, 
            IDonHangManager donHangManager, 
            ILichTrinhManager lichTrinhManager, 
            IXeManager xeManager,
            ITicketManager ticketManager,
            IThongKeManager thongKeManager,
            ICtDonHangManager ctDonHangManager)
        {
            _customerManager = customerManager;
            _donHangManager = donHangManager;
            _thongKeManager = thongKeManager;
            _ctdonHangManager = ctDonHangManager;
            seats = donHangManager.getGheDangChon();
            seat = donHangManager.getGhe();
            customer = _customerManager.GetResult();
            _lichTrinhManager = lichTrinhManager;
            _ticketManager = ticketManager;
            _xeManager = xeManager;
            
            var ticket = _ticketManager.GetTicketResult();
            var lichtrinh = ticket.IdLichTrinhNavigation;

            loaiXe = lichtrinh
                .IdXeNavigation.LoaiXe == (int)LoaiXe.Ngoi ? "Xe thường" : "Xe vip";
            chuyen = lichtrinh.NoiXuatPhat + " -- "
                + lichtrinh.NoiDen;
            ngayDi = lichtrinh.NgayDi.GetValueOrDefault().ToString("yyyy/MM/dd");
            gioDi = lichtrinh.NgayDi.GetValueOrDefault().ToString("hh:mm");
            tongtien = (int)(ticket.GiaVe * seats.Count);
            noiDon = lichtrinh.NoiXuatPhat;
            noiTra = lichtrinh.NoiDen;

            request = new CreateDonHang.Request
            {
                NgayDon = ngayDi,
                Cmnd = customer.id,
                TenKhachHang = customer.name,
                Email = customer.email,
                SoDienThoai = customer.phone,
                TinhTrang = "Chưa thanh toán",
                DiemDon = noiDon,
                DiemTra = noiTra,
                SoLuong = seats.Count,
                SoGhes = seats,
                IdVeXe = ticket.IdVe,
                GioDon = gioDi,
            };

            donHang = new DonHang
            {
                IdVeXe = request.IdVeXe,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiemDon = request.DiemDon,
                DiemTra = request.DiemTra,
                TinhTrang = request.TinhTrang == "Chưa thanh toán" ? 0 : 1,
                ThoiGianDon = DateTime.Parse(request.NgayDon + " " + request.GioDon + ":00"),
                Email = request.Email,
                Cmnd = request.Cmnd,
                GhiChu = request.GhiChu,
                SoLuong = request.SoLuong,
            };
            thongKe = new ThongKe
            {
                IdVe = request.IdVeXe,
                NgayDat = DateTime.Parse(request.NgayDon + " " + request.GioDon + ":00"),
                LoaiVe = ticket.LoaiVe,
                GiaVe = tongtien,
            };
        }

        public IActionResult OnPost()
        {
            _donHangManager.CreateDonHang(donHang).Wait();
            //_thongKeManager.CreateThongKe(thongKe).Wait();
            if (request.SoGhes.Count > 0)
            {
                var ghes = request.SoGhes;
                ghes.ForEach(g => 
                {
                    var ct = new CtDonHang
                    {
                        IdDonHang = donHang.IdDonHang,
                        SoGhe = g,
                    };
                    _ctdonHangManager.CreateCtDonHang(ct).Wait();
                });
            }

            var ticket = _ticketManager.GetTicketById(donHang.IdVeXe, x => x);

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(ticket.IdLichTrinh, y => y);

            var loaixe = _xeManager.GetXeById(lichtrinh.IdXe, x => x.LoaiXe);

            var soghe = 0;

            if (loaixe == (int)LoaiXe.Ngoi)
            {
                soghe = 40;
            }
            else
            {
                soghe = 32;
            }

            var sovedadat = _ctdonHangManager.GetCtDonHangByIdDonHang(donHang.IdDonHang, x => x);

            ticket.TinhTrang = 1;

            if (sovedadat.Count() == soghe)
            {
                _ticketManager.UpdateTicket(ticket).Wait();
            }

            _donHangManager.setGheDangChon(null);
            _donHangManager.setGhe("");
            return RedirectToPage("/KhachHang/ThongTinChuyenKhoan");
        }
    }
}
