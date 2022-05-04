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
        private ISessionManager _sessionManager;
        public Customer customer { get; set; }
        public List<int> seats { get; set; }
        [BindProperty]
        public bool state { get; set; }
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
            ICtDonHangManager ctDonHangManager, ISessionManager sessionManager)
        {
            _customerManager = customerManager;
            _donHangManager = donHangManager;
            _thongKeManager = thongKeManager;
            _ctdonHangManager = ctDonHangManager;
            _sessionManager = sessionManager;


            customer = _sessionManager.GetCustomerInformation();
            _lichTrinhManager = lichTrinhManager;
            _ticketManager = ticketManager;
            _xeManager = xeManager;

            seats = _sessionManager.GetGheChon();

            var ticket = _sessionManager.GetVeResult();

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(ticket.IdLichTrinh, x => x);

            var xe = _xeManager.GetXeById(lichtrinh.IdLichTrinh, x => x);
            loaiXe = xe.LoaiXe == (int)LoaiXe.Ngoi ? "Xe thường" : "Xe vip";

            var soluong = xe.LoaiXe == (int)LoaiXe.Ngoi ? 40 : 32;

            seat = GetViTri(soluong);


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
            var ticket = _sessionManager.GetVeResult();

            if (request.SoGhes.Count > 0)
            {

                var ghes = request.SoGhes;

                var listDonHang = _donHangManager.GetDonHangByIdVe(ticket.IdVe, x => x);// _ctdonHangManager.GetCtDonHangByIdDonHang(donHang.IdDonHang, x => x.SoGhe);

                var listdadat = new List<int>();

                listDonHang.ToList().ForEach(_donhang =>
                {
                    listdadat.AddRange(_ctdonHangManager.GetCtDonHangByIdDonHang(_donhang.IdDonHang, x => x.SoGhe));
                });

                foreach (var item in ghes)
                {
                    if (listdadat.Contains(item))
                    {
                        state = true;
                        _donHangManager.DeleteDonHang(donHang.IdDonHang).Wait();
                        return Page();
                    }
                }

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

        public string GetViTri(int soLuongGhe)
        {
            var gheDangChon = _sessionManager.GetGheChon();

            if (gheDangChon == null)
                return null;

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
