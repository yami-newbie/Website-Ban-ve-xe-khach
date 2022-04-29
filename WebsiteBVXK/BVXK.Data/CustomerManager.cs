using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class CustomerManager : ICustomerManager
    {
        public static Customer _customer;
        public void SaveData(Customer customer)
        {
            _customer = customer;
        }
        public Customer GetResult()
        {
            return _customer;
        }
    }
}
