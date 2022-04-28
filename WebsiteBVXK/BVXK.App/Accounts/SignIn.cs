using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.SignIn
{
    [Service]
    public class SignIn
    {
        IAccountManager _accountManager;

        public SignIn(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public bool Do(string username, string password)
        {
            string encryptPass = Encrypt.Encrypt.Do(password);

            return _accountManager.SignIn(username, encryptPass);
        }
    }
}
