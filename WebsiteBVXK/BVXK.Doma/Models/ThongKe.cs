using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class ThongKe
    {
        public int IdThongKe { get; set; }
        public int? IdVe { get; set; }
        public DateTime? NgayDat { get; set; }
        public int? LoaiVe { get; set; }
        public decimal? GiaVe { get; set; }
    }
}
