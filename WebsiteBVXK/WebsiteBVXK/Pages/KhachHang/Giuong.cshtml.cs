using BVXK.Application.GetDonHangs;
using BVXK.Application.GetXes;
using BVXK.Application.GetCtDonHangs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVXK.Domain.Infrastructure;
using BVXK.Domain.Models;
using BVXK.Domain.Enums;

namespace WebsiteBVXK.Pages.KhachHang
{
    public class GiuongModel : PageModel
    {
        private ITicketManager _ticketManager;
        private IXeManager _xeManager;
        private IDonHangManager _donHangManager;
        private ICtDonHangManager _ctDonHangManager;
        private ILichTrinhManager _lichTrinhManager;
        public int soLuongGhe { get; set; }
        public List<int> gheDaDat { get; set; }
        public List<int> gheDangChon { get; set; }
        public VeXe selected { get; set; }
        public List<GheModel> ghes { get; set; }
        [BindProperty]
        public string tang { get; set; }
        public GiuongModel(
            ITicketManager ticketManager, 
            ICtDonHangManager ctDonHangManager, 
            IDonHangManager donHangManager, 
            IXeManager xeManager, 
            ILichTrinhManager lichTrinhManager)
        {
            _ticketManager = ticketManager;
            _ctDonHangManager = ctDonHangManager;
            _donHangManager = donHangManager;
            _xeManager = xeManager;
            _lichTrinhManager = lichTrinhManager;
            
            tang = "Tầng Dưới";
            ghes = new List<GheModel>();
            gheDaDat = new List<int>();
            gheDangChon = new List<int>();

            selected = _ticketManager.GetTicketResult();
            var idXe = _lichTrinhManager.GetLichTrinhById(selected.IdLichTrinh, x => x.IdXe);
            var loaiXe = (int)_xeManager.GetXeById(idXe, x => x.LoaiXe);
            soLuongGhe = loaiXe == (int)LoaiXe.Ngoi ? 40 : 32;
            var donHangs = _donHangManager.GetDonHangByIdVe(selected.IdVe, x => x.IdDonHang);

            donHangs.ToList().ForEach(donHang =>
            {
                gheDaDat.AddRange(_ctDonHangManager.GetCtDonHangByIdDonHang(donHang, x => x.SoGhe));
            });

            for(int i = 0; i < soLuongGhe; i++)
            {
                ghes.Add(new GheModel
                {
                    index = i,
                    isPick = false,
                });
            }

            foreach(int index in gheDaDat)
            {
                ghes[index].isPick = true;
            }

        }

        public void OnPostClickGhe(int id)
        {
            if (!ghes.Any())
                return;

            var res = gheDaDat.Where(x => x == id).ToList();

            if(res.Count == 0)
            {
                ghes[id].isPick = true;
                gheDangChon.Add(id);
                return;
            }

            var res2 = gheDangChon.Where(x => x == id).ToList();

            if (res.Count != 0)
            {
                ghes[id].isPick = false;
                gheDangChon.Remove(id);
                return;
            }
        }

        public void OnPostSelectTang(int tang)
        {
            return;
        }

        public class GheModel
        {
            public int index { get; set; }
            public bool isPick { get; set; }
        }
    }
}
