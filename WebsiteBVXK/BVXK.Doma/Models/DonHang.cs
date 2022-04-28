using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class DonHang
    {
        public int IdDonHang { get; set; }
        public int IdVeXe { get; set; }
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public DateTime? ThoiGianDon { get; set; }
        public int? TinhTrang { get; set; }

        public virtual VeXe IdVeXeNavigation { get; set; } = null!;
    }
}
