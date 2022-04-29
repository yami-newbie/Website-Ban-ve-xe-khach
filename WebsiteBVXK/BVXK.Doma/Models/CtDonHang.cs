using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class CtDonHang
    {
        public int IdCtdonHang { get; set; }
        public int IdDonHang { get; set; }
        public int SoGhe { get; set; }

        public virtual DonHang IdDonHangNavigation { get; set; } = null!;
    }
}
