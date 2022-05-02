using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
    public interface IAccountManager
    {
        Task<int> SignUp(Account account);
        bool SignIn(string username, string password);
        bool GetIsLogin();
        void SetIsLogin(bool isLogin);
        TResult GetAccountByUsername<TResult>(string username, Func<Account, TResult> selector);

    }
}
