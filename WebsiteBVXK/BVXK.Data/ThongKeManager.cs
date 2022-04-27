using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class ThongKeManager : IThongKeManager
    {
        private BVXKContext _ctx;

        public ThongKeManager(BVXKContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateThongKe(ThongKe thongKe)
        {
            _ctx.ThongKes.Add(thongKe);

            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetThongKes<TResult>(Func<ThongKe, TResult> selector)
        {
            return _ctx.ThongKes.Select(selector).ToList();
        }

        public IEnumerable<TResult> GetThongKesBetweenDays<TResult>(DateTime from, DateTime to, Func<ThongKe, TResult> selector)
        {
            return _ctx.ThongKes.Where(
                x => x.NgayDat > from && x.NgayDat < to)
                .Select(selector).ToList();
        }
    }
}
