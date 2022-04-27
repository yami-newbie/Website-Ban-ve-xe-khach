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
        private IXesManager _xesManager;

        GetXes(IXesManager xesManager)
        {
            _xesManager = xesManager;
        }

        //public IEnumerable<XeViewModel> Do() =>
        //    _xesManager.GetXes(x => new XeViewModel
        //    {
        //        idXe = x.idXe,
        //        tenTaiXe = x.tenTaiXe,
        //        loaiXe = x.loaiXe,
        //        soDienThoai = x.soDienThoai,
        //        soLuongGhe = x.soLuongGhe,
        //        bienSo = x.bienSo,
        //    });

        public class XeViewModel
        {
            public int idXe { get; set; }
            public string tenTaiXe { get; set; }
            public Nullable<int> loaiXe { get; set; }
            public string soDienThoai { get; set; }
            public Nullable<int> soLuongGhe { get; set; }
            public string bienSo { get; set; }
        }
    }
}
