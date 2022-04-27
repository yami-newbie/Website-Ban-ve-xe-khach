using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class Xe
    {
        public Xe()
        {
            DonHangs = new HashSet<DonHang>();
            LichTrinhs = new HashSet<LichTrinh>();
            VeXes = new HashSet<VeXe>();
        }

        public int IdXe { get; set; }
        public string? TenTaiXe { get; set; }
        public int? LoaiXe { get; set; }
        public string? SoDienThoai { get; set; }
        public int? SoLuongGhe { get; set; }
        public string? BienSo { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual ICollection<LichTrinh> LichTrinhs { get; set; }
        public virtual ICollection<VeXe> VeXes { get; set; }
    }
}
