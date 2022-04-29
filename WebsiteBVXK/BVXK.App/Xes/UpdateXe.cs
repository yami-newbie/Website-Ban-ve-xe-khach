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
        private IXeManager _xesManager;

        public UpdateXe(IXeManager xesManager)
        {
            _xesManager = xesManager;
        }

        public async Task<Response> Do(Request request)
        {
            var xe = _xesManager.GetXeById(request.idXe, x => x);

            string resLoaiXe = "", resSoGhe = "";
            switch (request.loaiXe)
            {
                case (int)LoaiXe.Ngoi:
                    resLoaiXe = "Thường";
                    resSoGhe = "40 chỗ";
                    break;
                case (int)LoaiXe.Nam:
                    resLoaiXe = "Vip";
                    resSoGhe = "32 chỗ";
                    break;
            }

            xe.LoaiXe = request.loaiXe;
            xe.TenTaiXe = request.tenTaiXe;
            xe.SoDienThoai = request.soDienThoai;

            await _xesManager.UpdateXe(xe);

            
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
            public string soLuongGhe { get; set; }
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
