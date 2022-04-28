using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
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
        private ILichTrinhManager _lichTrinhManager;
        public GetTickets(ITicketManager ticketManager, ILichTrinhManager lichTrinhManager)
        {
            _ticketManager = ticketManager;
            _lichTrinhManager = lichTrinhManager;
        }
        public IEnumerable<TicketViewModel> Do()
        {
            var res = _ticketManager.GetTickets(x => x);

            return res.Select(x => getData(x));
        }

        private TicketViewModel getData(VeXe x)
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

            var lichtrinh = x.IdLichTrinhNavigation; //_lichTrinhManager.GetLichTrinhById(x.IdLichTrinh, y => y);

            return new TicketViewModel
            {
                idXe = lichtrinh.IdXe,
                idVe = x.IdVe,
                idLichTrinh = x.IdLichTrinh,
                giaVe = x.GiaVe,
                tinhTrang = resTinhTrang,
                loaiVe = resLoaiVe
            };
        }
            
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
