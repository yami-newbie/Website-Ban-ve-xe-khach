using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;


namespace BVXK.Application
{
    [Service]
    public class CustomerDetail
    {
        private ICustomerManager _customerManager;
        public CustomerDetail(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        public void Do(Customer customer)
            => _customerManager.SaveData(customer);
    }
}
