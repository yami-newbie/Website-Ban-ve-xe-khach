using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.GetLichTrinhs
{
	[Service]
	public class GetLichTrinhs
	{
		private ILichTrinhManager _lichTrinhManager;

		public GetLichTrinhs(ILichTrinhManager lichTrinhManager)
		{
			_lichTrinhManager = lichTrinhManager;
		}

		public IEnumerable<LichTrinhViewModel> Do()
			=> _lichTrinhManager.GetLichTrinhs(x =>
				new LichTrinhViewModel
				{
					IdLichTrinh = x.IdLichTrinh,
					IdXe = x.IdXe,
					NoiXuatPhat = x.NoiXuatPhat,
					NoiDen = x.NoiDen,
					NgayDi = x.NgayDi,
					NgayDen = x.NgayDen,
				});

		public class LichTrinhViewModel
		{
			public int IdLichTrinh { get; set; }
			public int IdXe { get; set; }
			public string? NoiXuatPhat { get; set; }
			public string? NoiDen { get; set; }
			public DateTime? NgayDi { get; set; }
			public DateTime? NgayDen { get; set; }
		}
	}
}
