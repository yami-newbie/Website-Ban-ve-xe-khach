using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
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
        public ICustomerManager _customerManager;
        public IDonHangManager _donHangManager;
        public ITicketManager _ticketManager;
        public IXeManager _xeManager;
        public ILichTrinhManager _lichTrinhManager;

        public XacNhanThongTinModel(
            ICustomerManager customerManager, 
            IDonHangManager donHangManager, 
            ILichTrinhManager lichTrinhManager, 
            IXeManager xeManager,
            ITicketManager ticketManager)
        {
            _customerManager = customerManager;
            _donHangManager = donHangManager;
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
            ngayDi = lichtrinh.NgayDi.GetValueOrDefault().ToString("dd/MM/yyyy");
            tongtien = (int)(ticket.GiaVe * seats.Count);
        }
    }
}
