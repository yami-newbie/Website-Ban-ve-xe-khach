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
        public TicketManager(BVXKContext ctx)
        {
            _ctx = ctx;
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
            return _ctx.VeXes.Where(x => x.IdVe == id).Select(selector).FirstOrDefault();
        }
        public Task<int> DeleteTicket(int id)
        {
            var veXe = _ctx.VeXes.FirstOrDefault(x => x.IdVe == id);
            _ctx.VeXes.Remove(veXe);
            return _ctx.SaveChangesAsync();
        }
    }
}
