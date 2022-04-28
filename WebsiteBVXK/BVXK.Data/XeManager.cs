using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class XeManager : IXeManager
    {
        private BVXKContext _ctx;

        public XeManager(BVXKContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TResult> GetXes<TResult>(Func<Xe, TResult> selector)
        {
            return _ctx.Xes.Select(selector).ToList();
        }

        public Task<int> UpdateXe(Xe xe)
        {
            _ctx.Xes.Update(xe);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> CreateXe(Xe xe)
        {
            _ctx.Xes.Add(xe);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetXeById<TResult>(int id, Func<Xe, TResult> selector)
        {
            return _ctx.Xes
                .Where(x => x.IdXe == id)
                .Select(selector)
                .FirstOrDefault();
        }
        public IEnumerable<TResult> GetXeBySeat<TResult>(int seat, Func<Xe, TResult> selector)
        {
            return _ctx.Xes.Where(x => x.SoLuongGhe == seat).Select(selector).ToList();
        }


        public Task<int> DeleteXe(int id)
        {
            var xe = _ctx.Xes.FirstOrDefault(x => x.IdXe == id);
            _ctx.Xes.Remove(xe);

            return _ctx.SaveChangesAsync();
        }
    }
}
