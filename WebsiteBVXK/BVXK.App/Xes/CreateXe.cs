using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.CreateXe
{
    [Service]
    public class CreateXe
    {
        private IXesManager _xesManager;

        public CreateXe(IXesManager xesManager)
        {
            _xesManager = xesManager;
        }

        public async Task<Response> Do(Request request)
        {
            var xe = new Xe
            {
                TenTaiXe = request.tenTaiXe,
                LoaiXe = request.loaiXe,
                SoDienThoai = request.soDienThoai,
                BienSo = request.bienSo,
                SoLuongGhe = request.soLuongGhe,
            };

            if (await _xesManager.CreateXe(xe) <= 0)
            {
                throw new Exception("Failed to create product");
            }

            return new Response
            {
                idXe = xe.IdXe,
                tenTaiXe = request.tenTaiXe,
                loaiXe = request.loaiXe,
                soDienThoai = request.soDienThoai,
                bienSo = request.bienSo,
                soLuongGhe = request.soLuongGhe,
            };
        }

        public class Request
        {
            public string tenTaiXe { get; set; }
            public int loaiXe { get; set; }
            public string soDienThoai { get; set; }
            public int soLuongGhe { get; set; }
            public string bienSo { get; set; }
        }

        public class Response
        {
            public int idXe { get; set; }
            public string tenTaiXe { get; set; }
            public int loaiXe { get; set; }
            public string soDienThoai { get; set; }
            public int soLuongGhe { get; set; }
            public string bienSo { get; set; }
        }
    }
}
