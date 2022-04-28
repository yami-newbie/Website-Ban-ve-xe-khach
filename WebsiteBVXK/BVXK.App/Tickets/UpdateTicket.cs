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
    public class UpdateTicket
    {
        private ITicketManager _ticketManager;
        public UpdateTicket(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }
        public async Task<Response> Do(Request request)
        {
            var veXe = _ticketManager.GetTicketById(request.idVe, x => x);

            veXe.IdXe = request.idXe;
            veXe.IdLichTrinh = request.idLichTrinh;
            veXe.GiaVe = request.giaVe;
            veXe.TinhTrang = request.tinhTrang;
            veXe.LoaiVe = request.loaiVe;

            await _ticketManager.UpdateTicket(veXe);

            string resLoaiVe = "", resTinhTrang = "";
            switch (veXe.LoaiVe)
            {
                case (int?)LoaiVe.Thuong:
                    resLoaiVe = "Thường";
                    break;
                case (int?)LoaiVe.Vip:
                    resLoaiVe = "Vip";
                    break;
            }
            switch (veXe.TinhTrang)
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
            return new Response
            {
                idVe = veXe.IdVe,
                idXe = veXe.IdXe,
                idLichTrinh = veXe.IdLichTrinh,
                giaVe = veXe.GiaVe,
                tinhTrang = resTinhTrang,
                loaiVe = resLoaiVe,
            };
        }
        public class Request
        {
            public int idVe { get; set; }
            public int idXe { get; set; }
            public int idLichTrinh { get; set; }
            public decimal? giaVe { get; set; }
            public int? tinhTrang { get; set; }
            public int? loaiVe { get; set; }
        }
        public class Response
        {
            public int idVe { get; set; }
            public int idXe { get; set; }
            public int idLichTrinh { get; set; }
            public decimal? giaVe { get; set; }
            public string? tinhTrang { get; set; }
            public string? loaiVe { get; set; }
        }
    }
}
