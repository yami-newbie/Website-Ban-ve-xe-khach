using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class XesManager : IXesManager
    {
        private BVXKContext _ctx;

        public XesManager(BVXKContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TResult> GetXes<TResult>(Func<Xe, TResult> selector)
        {
            return _ctx.Xes.Select(selector).ToList();
        }
    }
}
