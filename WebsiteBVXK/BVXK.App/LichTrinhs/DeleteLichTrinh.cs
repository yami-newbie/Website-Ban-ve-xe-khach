using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.DeleteLichTrinh
{
    [Service]
    public class DeleteLichTrinh
    {
        private ILichTrinhManager _lichTrinhManager;

        public DeleteLichTrinh(ILichTrinhManager lichTrinhManager)
        {
            _lichTrinhManager = lichTrinhManager;
        }

        public Task<int> Do(int id) => _lichTrinhManager.DeleteLichTrinh(id);
    }
}
