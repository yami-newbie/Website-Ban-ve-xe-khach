using BVXK.Domain.Models;
using System.Collections.Generic;

namespace BVXK.Domain.Infrastructure
{
    public interface ISessionManager
    {
        void AddCustomerInformation(Customer customer);
        void AddVeResult(VeXe veXes);
        void AddLichResult(List<LichTrinh> lichTrinhs);
        void AddGheChon(int gheChon);
        Customer GetCustomerInformation();
        VeXe GetVeResult();
        List<LichTrinh> GetLichTrinhResult();
        void RemoveGheChon(int soGhe);
        List<int> GetGheChon();
        string GetId();
    }
}