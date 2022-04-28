using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.CreateLichTrinh
{
    [Service]
    public class CreateLichTrinh
    {
        private ILichTrinhManager _lichTrinhManager;

        public CreateLichTrinh(ILichTrinhManager lichTrinhManager)
        {
            _lichTrinhManager = lichTrinhManager;
        }

        public async Task<Response> Do(Request request)
        {
            var lichtrinh = new LichTrinh();

            DateTime ngayden = new DateTime();
            DateTime ngaydi = new DateTime();

            DateTime.TryParse(request.NgayDi + " " + request.GioDi, out ngaydi);
            DateTime.TryParse(request.NgayDen + " " + request.GioDen, out ngayden);

            lichtrinh.IdXe = request.IdXe;
            lichtrinh.NgayDi = ngaydi;
            lichtrinh.NgayDen = ngayden;
            lichtrinh.NoiDen = request.NoiDen;
            lichtrinh.NoiXuatPhat = request.NoiXuatPhat;

            if (await _lichTrinhManager.CreateLichTrinh(lichtrinh) <= 0)
            {
                throw new Exception("Failed to create lich trinh");
            }

            return new Response
            {
                IdLichTrinh = lichtrinh.IdLichTrinh,
                NgayDen = request.NgayDen,
                NgayDi = request.NgayDi,
                GioDi = request.GioDi,
                GioDen = request.GioDen,
                NoiDen = request.NoiDen,
                NoiXuatPhat = request.NoiXuatPhat,
                IdXe = request.IdXe,
            };
        }

        public class Request
        {
            public int IdXe { get; set; }
            public string? NoiXuatPhat { get; set; }
            public string? NoiDen { get; set; }
            public string? NgayDi { get; set; }
            public string? GioDi { get; set; }
            public string? NgayDen { get; set; }
            public string? GioDen { get; set; }
        }

        public class Response
        {
            public int IdLichTrinh { get; set;}
            public int IdXe { get; set; }
            public string? NoiXuatPhat { get; set; }
            public string? NoiDen { get; set; }
            public string? NgayDi { get; set; }
            public string? GioDi { get; set; }
            public string? NgayDen { get; set; }
            public string? GioDen { get; set; }
        }
    }
}
