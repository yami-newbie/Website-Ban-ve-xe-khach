using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.SignUp
{
    [Service]
    public class SignUp
    {
        IAccountManager _accountManager;

        public SignUp(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public async Task<Response> Do(Request request)
        {
            var acc = _accountManager.GetAccountByUsername(request.Username, x => x);
            if(acc != null)
            {
                return null;
            }

            var account = new Account();

            string encryptPass = Encrypt.Encrypt.Do(request.Password);

            account.Avatar = request.Avatar;
            account.Username = request.Username;
            account.Password = encryptPass;
            account.PhoneNumber = request.PhoneNumber;
            account.Address = request.Address;
            account.Role = request.Role;
            account.DisplayName = request.DisplayName;

            if (await _accountManager.SignUp(account) <= 0)
            {
                throw new Exception("Failed to create account");
            }

            return new Response
            {
                Uid = account.Uid,
                Avatar = request.Avatar,
                Username = request.Username,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Role = request.Role,
                DisplayName = request.DisplayName,
            };
        }

        public class Request
        {
            public int? Role { get; set; }
            public string Username { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string? DisplayName { get; set; }
            public string? Address { get; set; }
            public string? PhoneNumber { get; set; }
            public byte[]? Avatar { get; set; }
        }
        public class Response
        {
            public int Uid { get; set; }
            public int? Role { get; set; }
            public string Username { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string? DisplayName { get; set; }
            public string? Address { get; set; }
            public string? PhoneNumber { get; set; }
            public byte[]? Avatar { get; set; }
        }
    }
}
