﻿using BVXK.Domain.Enums;
using BVXK.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVXK.Application.GetXe
{
    [Service]
    public class GetXe
    {
        private IXeManager _xesManager;

        public GetXe(IXeManager xesManager)
        {
            _xesManager = xesManager;
        }
        
        public XeViewModel Do(int id) =>
            _xesManager.GetXeById(id, x => {
                return new XeViewModel
                {
                    idXe = x.IdXe,
                    tenTaiXe = x.TenTaiXe,
                    loaiXe = (int)x.LoaiXe,
                    soDienThoai = x.SoDienThoai,
                    soLuongGhe = (int)x.SoLuongGhe,
                    bienSo = x.BienSo,
                };
            });

        public class XeViewModel
        {
            public int idXe { get; set; }
            public string tenTaiXe { get; set; }
            public int loaiXe { get; set; }
            public string soDienThoai { get; set; }
            public int soLuongGhe { get; set; }
            public string bienSo { get; set; }
        }
    }
}
