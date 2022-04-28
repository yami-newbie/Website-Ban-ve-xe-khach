using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class AccountManager : IAccountManager
    {
        BVXKContext _ctx;

        public AccountManager(BVXKContext ctx)
        {
            _ctx = ctx;
        }

        public bool SignIn(string username, string password)
        {
            var res = _ctx.Accounts
                    .Where(x => x.Username == username && x.Password == password)
                    .FirstOrDefault();
            return res != null;
        }

        public Task<int> SignUp(Account account)
        {
            _ctx.Accounts.Add(account);

            return _ctx.SaveChangesAsync();
        }
    }
}
