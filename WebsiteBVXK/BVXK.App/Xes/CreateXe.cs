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
        private IXeManager _xesManager;

        public CreateXe(IXeManager xesManager)
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
                throw new Exception("Failed to create xe");
            }

            string resLoaiXe = "", resSoGhe = "";

            switch (xe.LoaiXe)
            {
                case (int?)LoaiXe.Nam:
                    resLoaiXe = "Nằm";
                    break;
                case (int?)LoaiXe.Ngoi:
                    resLoaiXe = "Ngồi";
                    break;
            }
            switch (xe.SoLuongGhe)
            {
                case (int?)SoLuongGhe.C4:
                    resSoGhe = "4 chỗ";
                    break;
                case (int?)SoLuongGhe.C7:
                    resSoGhe = "7 chỗ";
                    break;
                case (int?)SoLuongGhe.C16:
                    resSoGhe = "16 chỗ";
                    break;
                case (int?)SoLuongGhe.C20:
                    resSoGhe = "20 chỗ";
                    break;
                case (int?)SoLuongGhe.C32:
                    resSoGhe = "32 chỗ";
                    break;
            }

            return new Response
            {
                idXe = xe.IdXe,
                tenTaiXe = request.tenTaiXe,
                loaiXe = resLoaiXe,
                soDienThoai = request.soDienThoai,
                bienSo = request.bienSo,
                soLuongGhe = resSoGhe,
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
            public string loaiXe { get; set; }
            public string soDienThoai { get; set; }
            public string soLuongGhe { get; set; }
            public string bienSo { get; set; }
        }
    }
}
