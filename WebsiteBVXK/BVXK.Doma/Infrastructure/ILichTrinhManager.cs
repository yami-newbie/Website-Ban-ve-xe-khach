using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
	public interface ILichTrinhManager
	{
        IEnumerable<TResult> GetLichTrinhs<TResult>(Func<LichTrinh, TResult> selector);
        TResult GetLichTrinhById<TResult>(int id, Func<LichTrinh, TResult> selector);
        Task<int> UpdateLichTrinh(LichTrinh lichTrinh);
        Task<int> CreateLichTrinh(LichTrinh lichTrinh);
        Task<int> DeleteLichTrinh(int id);
    }
}
