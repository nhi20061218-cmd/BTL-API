using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TonKhoBusiness : ITonKhoBusiness
    {
        private readonly ITonKhoRepository _res;
        public TonKhoBusiness(ITonKhoRepository res) => _res = res;

        public IEnumerable<TonKho> GetByKho(int? maKhoHang) => _res.GetByKho(maKhoHang);

        public IEnumerable<TonKho> GetHetHan(int soNgay) => _res.GetHetHan(soNgay);
    }
}
