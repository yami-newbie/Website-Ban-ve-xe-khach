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
        private ILichTrinhManager _lichTrinhManager;
        private IXeManager _xeManager;
        public GetTicket(ITicketManager ticketManager, ILichTrinhManager lichTrinhManager, IXeManager xeManager)
        {
            _ticketManager = ticketManager;
            _lichTrinhManager = lichTrinhManager;
            _xeManager = xeManager;
        }
        public TicketViewModel Do(int id)
        {
            var x = _ticketManager.GetTicketById(id, _x => _x);

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(x.IdLichTrinh, y => y);
            var xe = _xeManager.GetXeById(lichtrinh.IdXe, y => y);

            return new TicketViewModel
            {
                idXe = lichtrinh.IdXe,
                idVe = x.IdVe,
                idLichTrinh = x.IdLichTrinh,
                giaVe = x.GiaVe,
                tinhTrang = x.TinhTrang,
                loaiVe = xe.LoaiXe,
            };
        }
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
