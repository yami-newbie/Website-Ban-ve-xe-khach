using BVXK.Application.FindLichTrinh;
using BVXK.Application.Tickets;
using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBVXK.Infrastructure;

namespace WebsiteBVXK.Pages
{
    public class ThongTinVeModel : PageModel
    {
        public List<ThongTinVeViewModel> Titles { get; set; }
        private ILichTrinhManager _lichTrinhManager;
        private ITicketManager _ticketManager;
        private IXeManager _xeManager;
        private ISessionManager _sessionManager;
        public ThongTinVeModel(ILichTrinhManager lichTrinhManager, ITicketManager ticketManager, IXeManager xeManager, ISessionManager sessionManager)
        {
            _lichTrinhManager = lichTrinhManager;
            _ticketManager = ticketManager;
            _xeManager = xeManager;

            var res = _lichTrinhManager.GetFindResults();

            Titles = res.Select(x =>
            {

                var ticket = _ticketManager.GetTicketByIdLichTrinh(x.IdLichTrinh, _x => _x).FirstOrDefault();

                if (ticket == null)
                {
                    return null;
                }

                var xe = _xeManager.GetXeById(x.IdXe, _x => _x);

                int soghe = 0;

                switch (xe.LoaiXe)
                {
                    case (int?)LoaiXe.Ngoi:
                        soghe = 40;
                        break;
                    default:
                        soghe = 32;
                        break;
                }
                return new ThongTinVeViewModel
                {
                    DiemDen = x.NoiDen,
                    DiemDi = x.NoiXuatPhat,
                    GioDen = x.NgayDen.GetValueOrDefault().ToString("hh:mm"),
                    GioDi = x.NgayDi.GetValueOrDefault().ToString("hh:mm"),
                    GiaVe = (decimal)ticket.GiaVe,
                    LoaiXe = xe.LoaiXe == (int)LoaiXe.Ngoi ? "Xe Thường" : "Giường Vip",
                    idVe = ticket.IdVe,
                    SoGhe = soghe,
                };

            }).ToList();

            for (int i = 0; i < Titles.Count; i++)
            {
                var title = Titles[i];
                if (title == null)
                {
                    Titles.RemoveAt(i);
                }
            }
            _sessionManager = sessionManager;
        }

        public class ThongTinVeViewModel
        {
            public ThongTinVeViewModel()
            {
                DiemDen = "";
                DiemDi = "";
                GioDi = "";
                GioDen = "";
                LoaiXe = "";
                idVe = 0;
                SoGhe = 0;
                GiaVe = 0;
            }
            public string DiemDi { get; set; }
            public string DiemDen { get; set; }
            public string GioDi { get; set; }
            public string GioDen { get; set; }
            public string LoaiXe { get; set; }
            public decimal GiaVe { get; set; }
            public int SoGhe { get; set; }
            public int idVe { get; set; }
        }
        public IActionResult OnPostClick(int id, [FromServices] GetTicket getTicket)
        {
            var res = _ticketManager.GetTicketById(id, x => x);

            _sessionManager.AddVeResult(res);

            return RedirectToPage("/khachhang/giuong");
        }
    }
}
