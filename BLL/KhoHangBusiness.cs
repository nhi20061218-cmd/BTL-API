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
    public class KhoHangBusiness : IKhoHangBusiness
    {
        private readonly IKhoHangRepository _res;
        public KhoHangBusiness(IKhoHangRepository res) => _res = res;

        public int Create(KhoHang model) => _res.Create(model);
        public bool Update(KhoHang model) => _res.Update(model);
        public bool Delete(int id) => _res.Delete(id);
        public KhoHang GetById(int id) => _res.GetById(id);
        public IEnumerable<KhoHang> GetAll(int? maNhaPhanPhoi) => _res.GetAll(maNhaPhanPhoi);
    }
}
