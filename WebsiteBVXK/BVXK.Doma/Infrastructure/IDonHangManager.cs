using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
    public interface IDonHangManager
    {
        IEnumerable<TResult> GetDonHangs<TResult>(Func<DonHang, TResult> selector);
        TResult GetDonHangById<TResult>(int id, Func<DonHang, TResult> selector);
        Task<int> CreateDonHang(DonHang donHang);
        Task<int> DeleteDonHang(int id);
        List<int> getGheDangChon();
        public IEnumerable<TResult> GetDonHangByIdVe<TResult>(int id, Func<DonHang, TResult> selector);
        Task<int> UpdateDonHang(DonHang donHang);
        string getGhe();
        void setGhe(string ghe);
    }
}
