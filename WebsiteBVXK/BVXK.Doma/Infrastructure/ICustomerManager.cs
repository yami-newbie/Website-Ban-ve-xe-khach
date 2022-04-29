using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Domain.Infrastructure
{
    public interface ICustomerManager
    {
        void SaveData(Customer customer);
        Customer GetResult();
    }
}
