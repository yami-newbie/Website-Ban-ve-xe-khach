using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.CreateThongKe
{
    [Service]
    public class CreateThongKe
    {
        IThongKeManager _thongKeManager;

        public CreateThongKe(IThongKeManager thongKeManager)
        {
            _thongKeManager = thongKeManager;
        }

        public async Task<ThongKeViewModel> Do(ThongKeViewModel request)
        {
            ThongKe thongKe = new ThongKe();
            thongKe.IdVe = request.IdVe;
            thongKe.GiaVe = request.GiaVe;
            thongKe.NgayDat = DateTime.Parse(request.NgayDat);

            if (await _thongKeManager.CreateThongKe(thongKe) <= 0)
            {
                throw new Exception("Failed to create thong ke");
            }

            return request;
        }

        public class ThongKeViewModel
        {
            public int IdVe { get; set; }
            public string NgayDat { get; set; }
            public string LoaiVe { get; set; }
            public decimal GiaVe { get; set; }
        }
    }
}
