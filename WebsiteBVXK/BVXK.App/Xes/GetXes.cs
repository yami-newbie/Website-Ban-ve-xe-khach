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
                        case (int?)LoaiXe.Ngoi:
                            loaixe = "Thường";
                            soLuongGhe = "40 chỗ";
                            break;
                        case (int?)LoaiXe.Nam:
                            loaixe = "Vip";
                            soLuongGhe = "32 chỗ";
                            break;
                    }
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
