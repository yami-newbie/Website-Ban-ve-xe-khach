using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;

namespace BVXK.Database
{
	public class LichTrinhManager : ILichTrinhManager
	{

		private BVXKContext _ctx;

		public LichTrinhManager(BVXKContext ctx)
		{
			_ctx = ctx;
		}

		public Task<int> CreateLichTrinh(LichTrinh lichTrinh)
		{
			_ctx.LichTrinhs.Add(lichTrinh);

			return _ctx.SaveChangesAsync();
		}

		public Task<int> DeleteLichTrinh(int id)
		{
			var lichTrinh = _ctx.LichTrinhs.FirstOrDefault(x => x.IdLichTrinh == id);
			_ctx.LichTrinhs.Remove(lichTrinh);

			return _ctx.SaveChangesAsync();
		}

		public TResult GetLichTrinhById<TResult>(int id, Func<LichTrinh, TResult> selector)
		{
			return _ctx.LichTrinhs.Where(x => x.IdLichTrinh == id).Select(selector).FirstOrDefault();
		}

		public IEnumerable<TResult> GetLichTrinhs<TResult>(Func<LichTrinh, TResult> selector)
		{
			return _ctx.LichTrinhs.Select(selector).ToList();
		}

		public Task<int> UpdateLichTrinh(LichTrinh lichTrinh)
		{
			_ctx.LichTrinhs.Update(lichTrinh);

			return _ctx.SaveChangesAsync();
		}
	}
}
