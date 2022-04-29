using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            CtDonHangs = new HashSet<CtDonHang>();
        }

        public int IdDonHang { get; set; }
        public int IdVeXe { get; set; }
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public DateTime? ThoiGianDon { get; set; }
        public int? TinhTrang { get; set; }
        public string? DiemDon { get; set; }
        public string? DiemTra { get; set; }
        public string? Email { get; set; }
        public string? Cmnd { get; set; }
        public int? SoLuong { get; set; }
        public string? GhiChu { get; set; }

        public virtual VeXe IdVeXeNavigation { get; set; } = null!;
        public virtual ICollection<CtDonHang> CtDonHangs { get; set; }
    }
}
