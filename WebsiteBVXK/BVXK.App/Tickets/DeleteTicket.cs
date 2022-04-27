using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.Tickets
{
    [Service]
    public class DeleteTicket
    {
        private ITicketManager _ticketManager;
        public DeleteTicket(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }
        public Task<int> Do(int id) => _ticketManager.DeleteTicket(id);
    }
}
