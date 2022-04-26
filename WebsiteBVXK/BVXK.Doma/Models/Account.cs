using System;
using System.Collections.Generic;

namespace BVXK.Domain.Models
{
    public partial class Account
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
