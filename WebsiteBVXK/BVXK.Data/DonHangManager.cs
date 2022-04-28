using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class DonHangManager : IDonHangManager
    {
        BVXKContext _ctx;

        public DonHangManager(BVXKContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateDonHang(DonHang donHang)
        {
            _ctx.DonHangs.Add(donHang);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteDonHang(int id)
        {
            var donHang = _ctx.DonHangs.FirstOrDefault(x => x.IdDonHang == id);
            _ctx.DonHangs.Remove(donHang);

            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetDonHangByIdVe<TResult>(int id, Func<DonHang, TResult> selector)
        {
            return _ctx.DonHangs.Where(x => x.IdVeXe == id).Select(selector).ToList();
        }

        public TResult GetDonHangById<TResult>(int id, Func<DonHang, TResult> selector)
        {
            return _ctx.DonHangs.Where(x => x.IdDonHang == id).Select(selector).FirstOrDefault();
        }

        public IEnumerable<TResult> GetDonHangs<TResult>(Func<DonHang, TResult> selector)
        {
            return _ctx.DonHangs.Select(selector).ToList();
        }

        public Task<int> UpdateDonHang(DonHang donHang)
        {
            _ctx.DonHangs.Update(donHang);

            return _ctx.SaveChangesAsync();
        }
    }
}
