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
    public class SieuThiBusiness : ISieuThiBusiness
    {
        private readonly ISieuThiRepository _res;
        public SieuThiBusiness(ISieuThiRepository res) => _res = res;

        public int Create(SieuThi model) => _res.Create(model);
        public IEnumerable<SieuThi> GetByUser(int maNguoiDung) => _res.GetByUser(maNguoiDung);
        public IEnumerable<SieuThi> GetAll() => _res.GetAll();
        public bool Delete(int id) => _res.Delete(id);
    }
}
