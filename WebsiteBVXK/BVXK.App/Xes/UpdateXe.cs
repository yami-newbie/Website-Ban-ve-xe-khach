using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.UpdateXe
{
    [Service]
    public class UpdateXe
    {
        private IXesManager _xesManager;

        public UpdateXe(IXesManager xesManager)
        {
            _xesManager = xesManager;
        }

        public async Task<Response> Do(Request request)
        {
            var xe = _xesManager.GetXeById(request.idXe, x => x);
            
            xe.LoaiXe = request.loaiXe;
            xe.TenTaiXe = request.tenTaiXe;
            xe.SoLuongGhe = request.soLuongGhe;
            xe.SoDienThoai = request.soDienThoai;
            
            await _xesManager.UpdateXe(xe);

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
                idXe = request.idXe,
                loaiXe = resLoaiXe,
                tenTaiXe = request.tenTaiXe,
                soDienThoai = request.soDienThoai,
                soLuongGhe = resSoGhe,
                bienSo = request.bienSo,
            };

        }

        public class Request
        {
            public int idXe { get; set; }
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
