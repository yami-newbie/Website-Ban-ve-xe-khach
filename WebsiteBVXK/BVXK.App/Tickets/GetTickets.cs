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
                string loaiVe = "", tinhTrang = "";
                if (x.LoaiVe != null)
                {
                    switch (x.LoaiVe)
                    {
                        case (int?)LoaiVe.Thuong:
                            loaiVe = "Thường";
                            break;
                        case (int?)LoaiVe.Vip:
                            loaiVe = "Vip";
                            break;
                    }
                }
                if (x.TinhTrang != null)
                {
                    switch (x.TinhTrang)
                    {
                        case (int?)TinhTrangVe.DaBan:
                            tinhTrang = "Đã bán";
                            break;
                        case (int?)TinhTrangVe.GiuCho:
                            tinhTrang = "Giữ chỗ";
                            break;
                        case (int?)TinhTrangVe.ChuaBan:
                            tinhTrang = "Chưa bán";
                            break;
                    }
                }
                return new TicketViewModel
                {
                    idXe = x.IdXe,
                    idVe = x.IdVe,
                    idLichTrinh = x.IdLichTrinh,
                    giaVe = x.GiaVe,
                    tinhTrang = x.TinhTrang,
                    loaiVe = x.LoaiVe,
                };
            });
        public class TicketViewModel
        {
            public int idXe { get; set; }
            public int idVe { get; set; }
            public int idLichTrinh { get; set; }
            public decimal? giaVe { get; set; }
            public int? tinhTrang { get; set; }
            public int? loaiVe { get; set; }
        }
    }
}
