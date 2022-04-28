using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.Tickets
{
    [Service]
    public class GetTickets
    {
        private ITicketManager _ticketManager;
        public GetTickets(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }
        public IEnumerable<TicketViewModel> Do() =>
            _ticketManager.GetTickets(x =>
            {
                string resLoaiVe = "", resTinhTrang = "";
                if (x.LoaiVe != null)
                {
                    switch (x.LoaiVe)
                    {
                        case (int?)LoaiVe.Thuong:
                            resLoaiVe = "Thường";
                            break;
                        case (int?)LoaiVe.Vip:
                            resLoaiVe = "Vip";
                            break;
                    }
                }
                if (x.TinhTrang != null)
                {
                    switch (x.TinhTrang)
                    {
                        case (int?)TinhTrangVe.DaBan:
                            resTinhTrang = "Đã bán";
                            break;
                        case (int?)TinhTrangVe.GiuCho:
                            resTinhTrang = "Giữ chỗ";
                            break;
                        case (int?)TinhTrangVe.ChuaBan:
                            resTinhTrang = "Chưa bán";
                            break;
                    }
                }
                return new TicketViewModel
                {
                    idXe = x.IdXe,
                    idVe = x.IdVe,
                    idLichTrinh = x.IdLichTrinh,
                    giaVe = x.GiaVe,
                    tinhTrang = resTinhTrang,
                    loaiVe = resLoaiVe
                };
            });
        public class TicketViewModel
        {
            public int idXe { get; set; }
            public int idVe { get; set; }
            public int idLichTrinh { get; set; }
            public decimal? giaVe { get; set; }
            public string? tinhTrang { get; set; }
            public string? loaiVe { get; set; }
        }
    }
}
