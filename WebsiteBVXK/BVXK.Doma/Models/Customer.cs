using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Models
{
    public partial class Customer
    {
        public Customer(string ten, string sdt, string mail, string cmnd)
        {
            name = ten;
            phone = sdt;
            email = mail;
            id = cmnd;
        }
        public string? name { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? id { get; set; }
    }
}
