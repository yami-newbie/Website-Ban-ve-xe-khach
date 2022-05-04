using BVXK.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using BVXK.Application.FindLichTrinh;
using BVXK.Domain.Infrastructure;

namespace WebsiteBVXK.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private const string KeyDonHang = "donhang";
        private const string KeyCustomerInfo = "khachhang-info";
        private const string KeyVeResultInfo = "ve-result-info";
        private const string KeyLichTrinhResultInfo = "lichtrinh-result-info";
        private const string KeySelectInfo = "select-info";
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public string GetId() => _session.Id;

        public void AddCustomerInformation(Customer customer)
        {
            var stringObject = JsonConvert.SerializeObject(customer);

            _session.SetString(KeyCustomerInfo, stringObject);
        }

        public void AddGheChon(int gheChon)
        {
            var danhsach = new List<int>();
            var stringObject = _session.GetString(KeySelectInfo);

            if (!string.IsNullOrEmpty(stringObject))
            {
                danhsach = JsonConvert.DeserializeObject<List<int>>(stringObject);
            }

            danhsach.Add(gheChon);

            stringObject = JsonConvert.SerializeObject(danhsach);

            _session.SetString(KeySelectInfo, stringObject);
        }

        public Customer GetCustomerInformation()
        {
            var stringObject = _session.GetString(KeyCustomerInfo);

            if (string.IsNullOrEmpty(stringObject))
                return null;

            var customerInformation = JsonConvert.DeserializeObject<Customer>(stringObject);

            return customerInformation;
        }

        public void ClearCart()
        {
            _session.Remove(KeyDonHang);
        }

        public void RemoveGheChon(int soGhe)
        {
            var danhsach = new List<int>();
            var stringObject = _session.GetString(KeySelectInfo);

            if (string.IsNullOrEmpty(stringObject)) return;

            danhsach = JsonConvert.DeserializeObject<List<int>>(stringObject);

            if (!danhsach.Contains(soGhe)) return;

            var product = danhsach.IndexOf(soGhe);

            danhsach.RemoveAt(product);

            stringObject = JsonConvert.SerializeObject(danhsach);

            _session.SetString(KeySelectInfo, stringObject);
        }

       

        public void AddVeResult(VeXe veXes)
        {
            var danhsach = new VeXe();
            var stringObject = _session.GetString(KeyVeResultInfo);

            if (!string.IsNullOrEmpty(stringObject))
            {
                danhsach = JsonConvert.DeserializeObject<VeXe>(stringObject);
            }

            danhsach = veXes;

            stringObject = JsonConvert.SerializeObject(danhsach);

            _session.SetString(KeyVeResultInfo, stringObject);
        }

        public VeXe GetVeResult()
        {
            var stringObject = _session.GetString(KeyVeResultInfo);

            if (string.IsNullOrEmpty(stringObject))
                return null;

            var customerInformation = JsonConvert.DeserializeObject<VeXe>(stringObject);

            return customerInformation;
        }

        public void AddLichResult(List<LichTrinh> lichtrinhs)
        {
            var danhsach = new List<LichTrinh>();
            var stringObject = _session.GetString(KeyLichTrinhResultInfo);

            if (!string.IsNullOrEmpty(stringObject))
            {
                danhsach = JsonConvert.DeserializeObject<List<LichTrinh>>(stringObject);
            }

            danhsach.AddRange(lichtrinhs);

            stringObject = JsonConvert.SerializeObject(danhsach);

            _session.SetString(KeyLichTrinhResultInfo, stringObject);
        }

        public List<LichTrinh> GetLichTrinhResult()
        {
            var stringObject = _session.GetString(KeyLichTrinhResultInfo);

            if (string.IsNullOrEmpty(stringObject))
                return new List<LichTrinh>();

            var customerInformation = JsonConvert.DeserializeObject<List<LichTrinh>>(stringObject);

            return customerInformation;
        }

        public List<int> GetGheChon()
        {
            var stringObject = _session.GetString(KeySelectInfo);

            if (string.IsNullOrEmpty(stringObject))
                return new List<int>();

            var customerInformation = JsonConvert.DeserializeObject<List<int>>(stringObject);

            return customerInformation;
        }
    }
}
