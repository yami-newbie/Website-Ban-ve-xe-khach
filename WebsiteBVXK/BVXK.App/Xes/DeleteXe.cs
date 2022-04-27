using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.DeleteXe
{
    [Service]
    public class DeleteXe
    {
        private IXesManager _xesManager;

        public DeleteXe(IXesManager xesManager)
        {
            _xesManager = xesManager;
        }

        public Task<int> Do(int id) => _xesManager.DeleteXe(id);
    }
}
