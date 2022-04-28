using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.GetXes
{
    [Service]
    public class GetXes
    {
        private IXeManager _xesManager;

        public GetXes(IXeManager xesManager)
        {
            _xesManager = xesManager;
        }

        public IEnumerable<XeViewModel> Do() =>
            _xesManager.GetXes(x => {
                string loaixe = "";
                string soLuongGhe = "";
                if (x.LoaiXe != null)
                {
                    switch (x.LoaiXe)
                    {
                        case (int?)LoaiXe.Nam:
                            loaixe = "Nằm";
                            break;
                        case (int?)LoaiXe.Ngoi:
                            loaixe = "Ngồi";
                            break ;
                    }
                }
                switch(x.SoLuongGhe)
                {
                    case (int?)SoLuongGhe.C4:
                        soLuongGhe = "4 chỗ";
                        break;
                    case (int?)SoLuongGhe.C7:
                        soLuongGhe = "7 chỗ";
                        break;
                    case (int?)SoLuongGhe.C16:
                        soLuongGhe = "16 chỗ";
                        break;
                    case (int?)SoLuongGhe.C20:
                        soLuongGhe = "20 chỗ";
                        break;
                    case (int?)SoLuongGhe.C32:
                        soLuongGhe = "32 chỗ";
                        break;
                }
                
                return new XeViewModel
                {
                    idXe = x.IdXe,
                    tenTaiXe = x.TenTaiXe,
                    loaiXe = loaixe,
                    soDienThoai = x.SoDienThoai,
                    soLuongGhe = soLuongGhe,
                    bienSo = x.BienSo,
                };
                });

        public class XeViewModel
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
