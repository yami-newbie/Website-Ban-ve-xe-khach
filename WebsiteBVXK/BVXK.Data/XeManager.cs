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
        private ILichTrinhManager _lichTrinhManager;

        public XeManager(BVXKContext ctx, ILichTrinhManager lichTrinhManager)
        {
            _ctx = ctx;
            _lichTrinhManager = lichTrinhManager;
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

        public Task<int> DeleteXe(int id)
        {

            var res = _lichTrinhManager.GetLichTringByIdXe(id, x => x.IdLichTrinh);

            res.ToList().ForEach(x =>
            {
                _lichTrinhManager.DeleteLichTrinh(x).Wait();
            });

            var xe = _ctx.Xes.FirstOrDefault(x => x.IdXe == id);

            _ctx.Xes.Remove(xe);

            return _ctx.SaveChangesAsync();
        }
    }
}
