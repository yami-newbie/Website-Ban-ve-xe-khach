using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
    public interface ITicketManager
    {
        IEnumerable<TResult> GetTickets<TResult>(Func<VeXe, TResult> selector);
        TResult GetTicketById<TResult>(int id, Func<VeXe, TResult> selector);
        Task<int> UpdateTicket(VeXe vexe);
        Task<int> CreateTicket(VeXe vexe);
        public IEnumerable<TResult> GetTicketByIdLichTrinh<TResult>(int id, Func<VeXe, TResult> selector);
        Task<int> DeleteTicket(int id);
    }
}
