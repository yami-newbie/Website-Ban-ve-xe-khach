using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class CtDonHangManager : ICtDonHangManager
    {
        private BVXKContext _ctx;
        public CtDonHangManager(BVXKContext ctx) { _ctx = ctx; }
        public Task<int> CreateCtDonHang(CtDonHang ct)
        {
            _ctx.CtDonHangs.Add(ct);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteCtDonHang(int id)
        {
            var ct = _ctx.CtDonHangs.FirstOrDefault(x=>x.IdCtdonHang == id);

            _ctx.CtDonHangs.Remove(ct);

            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetCtDonHang<TResult>(Func<CtDonHang, TResult> selector)
        {
            return _ctx.CtDonHangs.Select(selector).ToList();
        }

        public TResult GetCtDonHangById<TResult>(int id, Func<CtDonHang, TResult> selector)
        {
            return _ctx.CtDonHangs.Where(x => x.IdCtdonHang == id).Select(selector).FirstOrDefault();
        }

        public IEnumerable<TResult> GetCtDonHangByIdDonHang<TResult>(int idDonHang, Func<CtDonHang, TResult> selector)
        {
            return _ctx.CtDonHangs.Where(x => x.IdDonHang == idDonHang).Select(selector).ToList();
        }

        public Task<int> UpdateCtDonHang(CtDonHang ct)
        {
            _ctx.CtDonHangs.Update(ct);

            return _ctx.SaveChangesAsync();
        }
    }
}
