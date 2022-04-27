using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
    public interface IXesManager
    {
        IEnumerable<TResult> GetXes<TResult>(Func<Xe, TResult> selector);

        Task<int> UpdateXe(Xe xe);
        Task<int> CreateXe(Xe xe);
        Task<int> DeleteXe(int id);

        TResult GetXeById<TResult>(int id, Func<Xe, TResult> selector);


        

    }
}
