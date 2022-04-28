using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.FindXe
{
    public class FindXe
    {
        [Service]

        private IXeManager _xesManager;

        public FindXe(IXeManager xesManager)
        {
            _xesManager = xesManager;
        }
        public IEnumerable<int> Do(int seat) =>
            _xesManager.GetXeBySeat(seat, x =>
            {
                return x.IdXe;
            });
    }
}
