using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
    public interface ICtDonHangManager
    {
        Task<int> CreateCtDonHang(CtDonHang ct);
        Task<int> UpdateCtDonHang(CtDonHang ct);
        Task<int> DeleteCtDonHang(int id);
        IEnumerable<TResult> GetCtDonHang<TResult>(Func<CtDonHang, TResult> selector);
        TResult GetCtDonHangById<TResult>(int id, Func<CtDonHang, TResult> selector);
        IEnumerable<TResult> GetCtDonHangByIdDonHang<TResult>(int idDonHang, Func<CtDonHang, TResult> selector);
    }
}
