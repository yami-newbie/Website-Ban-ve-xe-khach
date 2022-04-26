using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class DonHang
    {
        public int IdDonHang { get; set; }
        public int IdVeXe { get; set; }
        public int IdXe { get; set; }
        public int IdLichTrinh { get; set; }
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public DateTime? ThoiGianDon { get; set; }
        public string? DiemDon { get; set; }
        public string? DiemTra { get; set; }
        public decimal? TongTien { get; set; }
        public int? TinhTrang { get; set; }

        public virtual LichTrinh IdLichTrinhNavigation { get; set; } = null!;
        public virtual VeXe IdVeXeNavigation { get; set; } = null!;
        public virtual Xe IdXeNavigation { get; set; } = null!;
    }
}
