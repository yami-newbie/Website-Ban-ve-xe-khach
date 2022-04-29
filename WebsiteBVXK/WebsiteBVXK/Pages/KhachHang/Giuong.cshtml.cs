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
        public string ghe { get; set; }
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
            gheDangChon = _donHangManager.getGheDangChon();

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
                    isPick = 0,
                });
            }

            foreach(int index in gheDaDat)
            {
                ghes[index].isPick = -1;
            }

            foreach (int index in gheDangChon)
            {
                ghes[index].isPick = 1;
            }
        }

        public string GetViTri()
        {
            gheDangChon = _donHangManager.getGheDangChon();

            if (gheDangChon.Count <= 0)
                return "";

            string res = "";

            foreach (int i in gheDangChon)
            {
                var _i = i;
                if (i >= soLuongGhe / 2)
                {
                    _i -= soLuongGhe / 2;
                }

                switch (_i % 3)
                {
                    case 0:
                        res += "A";
                        break;
                    case 1:
                        res += "B";
                        break;
                    default:
                        res += "C";
                        break;
                }

                var y = _i / 3;

                if (i < soLuongGhe / 2)
                {
                    res += (y * 2 + 1).ToString();
                }
                else
                {
                    res += (y * 2 + 2).ToString();
                }

                res += ", ";
            }

            return res.Substring(0, res.Length - 2);
        }
        public void OnPostClickGhe(int id)
        {
            if (!ghes.Any())
                return;


            var res = gheDaDat.Where(x => x == id).ToList();

            var res2 = gheDangChon.Where(x => x == id).ToList();

            if (res2.Count != 0)
            {
                ghes[id].isPick = 0;
                gheDangChon.Remove(id);
                _donHangManager.setGheDangChon(gheDangChon);
                return;
            }

            if(res.Count == 0)
            {
                ghes[id].isPick = 1;
                gheDangChon.Add(id);
                _donHangManager.setGheDangChon(gheDangChon);
                return;
            }
        }

        public class GheModel
        {
            public int index { get; set; }
            public int isPick { get; set; }
        }
        public IActionResult OnPost()
        {
            _donHangManager.setGhe(GetViTri());
            return RedirectToPage("/KhachHang/ThongTinKhachHang");
        }
    }
}
