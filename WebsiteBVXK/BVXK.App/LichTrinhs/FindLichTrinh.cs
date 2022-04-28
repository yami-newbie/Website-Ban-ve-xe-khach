using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.FindLichTrinh
{
    [Service]
    public class FindLichTrinh
    {
        private ILichTrinhManager _lichTrinhManager;

        public FindLichTrinh(ILichTrinhManager lichTrinhManager, IXeManager xeManager)
        {
            _lichTrinhManager = lichTrinhManager;
        }

        public IEnumerable<LichTrinhViewModel> Do(string start, string destination, DateTime startDate)
            => _lichTrinhManager.FindLichTrinh(start, destination, startDate, x => new LichTrinhViewModel
            {
                IdLichTrinh = x.IdLichTrinh,
                IdXe = x.IdXe,
                NoiXuatPhat = x.NoiXuatPhat,
                NoiDen = x.NoiDen,
                NgayDen = x.NgayDen.GetValueOrDefault().ToString("yyyy-MM-dd"),
                GioDen = x.NgayDen.GetValueOrDefault().ToString("hh:mm"),
                NgayDi = x.NgayDi.GetValueOrDefault().ToString("yyyy-MM-dd"),
                GioDi = x.NgayDi.GetValueOrDefault().ToString("hh:mm"),
            });
        public class LichTrinhViewModel
        {
            public int IdLichTrinh { get; set; }
            public int IdXe { get; set; }
            public string? NoiXuatPhat { get; set; }
            public string? NoiDen { get; set; }
            public string NgayDi { get; set; }
            public string GioDi { get; set; }
            public string NgayDen { get; set; }
            public string GioDen { get; set; }
        }
    }
}
