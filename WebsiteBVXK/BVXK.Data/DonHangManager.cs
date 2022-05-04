using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Database
{
    public class DonHangManager : IDonHangManager
    {
        BVXKContext _ctx;
        private ICtDonHangManager _ctDonHangManager;
        private IThongKeManager _thongKeManager;
        public static List<int> gheDangChon { get; set; }
        public static string ghe { get; set; }


        public DonHangManager(BVXKContext ctx, ICtDonHangManager ctDonHangManager, IThongKeManager thongKeManager)
        {
            _ctx = ctx;
            _ctDonHangManager = ctDonHangManager;
            if (gheDangChon == null)
            {
                gheDangChon = new List<int>();
            }
            if (ghe == null)
                ghe = "";
            _thongKeManager = thongKeManager;
        }

        public Task<int> CreateDonHang(DonHang donHang)
        {
            _ctx.DonHangs.Add(donHang);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteDonHang(int id)
        {
            _thongKeManager.DeleteThongKeByIdDonHang(id).Wait();

            var donHang = _ctx.DonHangs.FirstOrDefault(x => x.IdDonHang == id);

            if (donHang == null) return _ctx.SaveChangesAsync();

            var cts = _ctDonHangManager.GetCtDonHangByIdDonHang(id, x => x);

            cts.ToList().ForEach(x => _ctDonHangManager.DeleteCtDonHang(x.IdCtdonHang).Wait());

            _ctx.DonHangs.Remove(donHang);

            return _ctx.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetDonHangByIdVe<TResult>(int id, Func<DonHang, TResult> selector)
        {
            return _ctx.DonHangs.Where(x => x.IdVeXe == id).Select(selector).ToList();
        }

        public TResult GetDonHangById<TResult>(int id, Func<DonHang, TResult> selector)
        {
            return _ctx.DonHangs.Where(x => x.IdDonHang == id).Select(selector).FirstOrDefault();
        }

        public IEnumerable<TResult> GetDonHangs<TResult>(Func<DonHang, TResult> selector)
        {
            return _ctx.DonHangs.Select(selector).ToList();
        }

        public Task<int> UpdateDonHang(DonHang donHang)
        {
            _ctx.DonHangs.Update(donHang);

            return _ctx.SaveChangesAsync();
        }

        public List<int> getGheDangChon()
        {
            return gheDangChon;
        }
        public string getGhe()
        {
            return ghe;
        }
        public void setGhe(string ge)
        {
            ghe = ge;
        }

        public void setGheDangChon(List<int> list)
        {
            gheDangChon = list;
        }

        public List<int> GetListGheDuocChonByIdDonHang(int id)
        {
            return _ctDonHangManager.GetCtDonHangByIdDonHang(id, x => x.SoGhe).ToList();
        }
    }
}
