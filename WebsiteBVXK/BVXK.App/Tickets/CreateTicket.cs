﻿using BVXK.Domain.Enums;
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
    public class CreateTicket
    {
        private ITicketManager _ticketManager;
        private ILichTrinhManager _lichTrinhManager;
        public CreateTicket(ITicketManager ticketManager, ILichTrinhManager lichTrinhManager)
        {
            _ticketManager = ticketManager;
            _lichTrinhManager = lichTrinhManager;
        }
        public async Task<Response> Do(Request request)
        {
            var veXe = new VeXe
            {
                IdLichTrinh = request.idLichTrinh,
                GiaVe = request.giaVe,
                TinhTrang = request.tinhTrang,
                LoaiVe = request.loaiVe,
            };
            
            if (await _ticketManager.CreateTicket(veXe) <= 0)
            {
                throw new Exception("Failed to create product");
            }
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

            var lichtrinh = _lichTrinhManager.GetLichTrinhById(veXe.IdLichTrinh, y => y);


            return new Response
            {
                idVe = veXe.IdVe,
                idXe = lichtrinh.IdXe,
                idLichTrinh = veXe.IdLichTrinh,
                giaVe = veXe.GiaVe,
                tinhTrang = resTinhTrang,
                loaiVe = resLoaiVe,
            };
        }
        public class Request
        {
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
