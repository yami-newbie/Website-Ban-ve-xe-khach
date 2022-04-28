using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class LichTrinh
    {
        public LichTrinh()
        {
            VeXes = new HashSet<VeXe>();
        }

        public int IdLichTrinh { get; set; }
        public int IdXe { get; set; }
        public string? NoiXuatPhat { get; set; }
        public string? NoiDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public DateTime? NgayDen { get; set; }
        public byte[]? Hinh1 { get; set; }
        public byte[]? Hinh2 { get; set; }

        public virtual Xe IdXeNavigation { get; set; } = null!;
        public virtual ICollection<VeXe> VeXes { get; set; }
    }
}
