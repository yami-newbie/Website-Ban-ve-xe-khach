using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class TicketManager : ITicketManager
    {
        private BVXKContext _ctx;
        private IDonHangManager _donhangManager;
        public static  List<VeXe> result;
        public TicketManager(BVXKContext ctx, IDonHangManager donhangManager)
        {
            _ctx = ctx;
            _donhangManager = donhangManager;
        }
        public IEnumerable<TResult> GetTickets<TResult>(Func<VeXe, TResult> selector)
        {
            return _ctx.VeXes.Select(selector).ToList();
        }
        public Task<int> UpdateTicket (VeXe veXe)
        {
            _ctx.VeXes.Update(veXe);
            return _ctx.SaveChangesAsync();
        }
        public Task<int> CreateTicket(VeXe veXe)
        {
            _ctx.VeXes.Add(veXe);
            return _ctx.SaveChangesAsync();
        }
        public TResult GetTicketById<TResult>(int id, Func<VeXe, TResult> selector)
        {
            result = _ctx.VeXes.Where(x => x.IdVe == id).ToList();
            return result.Select(selector).FirstOrDefault();
        }
        public Task<int> DeleteTicket(int id)
        {
            var res = _donhangManager.GetDonHangByIdVe(id, x => x.IdDonHang);

            res.ToList().ForEach(x =>
            {
                _donhangManager.DeleteDonHang(x).Wait();
            });

            var veXe = _ctx.VeXes.FirstOrDefault(x => x.IdVe == id);
            _ctx.VeXes.Remove(veXe);
            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetTicketByIdLichTrinh<TResult>(int id, Func<VeXe, TResult> selector)
        {
            return _ctx.VeXes.Where(x => x.IdLichTrinh == id).Select(selector).ToList();
        }
        public VeXe GetTicketResult()
        {
            return result.FirstOrDefault();
        }
    }
}
