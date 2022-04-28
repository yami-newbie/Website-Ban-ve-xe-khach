using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
    public interface IThongKeManager
    {
        IEnumerable<TResult> GetThongKes<TResult>(Func<ThongKe, TResult> selector);
        IEnumerable<TResult> GetThongKesBetweenDays<TResult>(DateTime from, DateTime to, Func<ThongKe, TResult> selector);
        Task<int> CreateThongKe(ThongKe thongKe);
    }
}
