using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.Tickets
{
    [Service]
    public class GetTicket
    {
        private ITicketManager _ticketManager;
        public GetTicket(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }
        public TicketViewModel Do(int id) =>
            _ticketManager.GetTicketById(id, x =>
            {
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
