using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.GetThongKes
{
    [Service]
    public class GetThongKes
    {
        IThongKeManager _thongKeManager;

        public GetThongKes(IThongKeManager thongKeManager)
        {
            _thongKeManager = thongKeManager;
        }

        public IEnumerable<ThongKeViewModel> Do()
            => _thongKeManager.GetThongKes(x =>
            {
                string loaive = "";

                switch (x.LoaiVe)
                {
                    case (int?)LoaiVe.Thuong:
                        loaive = "Thường";
                        break;
                    case (int?)LoaiVe.Vip:
                        loaive = "Vip";
                        break;
                }

                return new ThongKeViewModel
                {
                    IdVe = (int)x.IdVe,
                    NgayDat = x.NgayDat.GetValueOrDefault().ToString("yyyy-MM-dd"),
                    LoaiVe = loaive,
                    GiaVe = (decimal)x.GiaVe,
                    SoLuong = (int)x.SoLuong,
                };
            });

        public class ThongKeViewModel
        {
            public int IdVe { get; set; }
            public int SoLuong { get; set; }
            public string? NgayDat { get; set; }
            public string LoaiVe { get; set;}
            public decimal GiaVe { get; set; }
        }
    }
}
