using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class VeXe
    {
        public VeXe()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int IdVe { get; set; }
        public int IdXe { get; set; }
        public int IdLichTrinh { get; set; }
        public decimal? GiaVe { get; set; }
        public int? TinhTrang { get; set; }
        public int? LoaiVe { get; set; }

        public virtual Xe IdXeNavigation { get; set; } = null!;
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
