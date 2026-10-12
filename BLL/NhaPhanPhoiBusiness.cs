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
    public class NhaPhanPhoiBusiness : INhaPhanPhoiBusiness
    {
        private readonly INhaPhanPhoiRepository _res;
        public NhaPhanPhoiBusiness(INhaPhanPhoiRepository res) => _res = res;

        public int Create(NhaPhanPhoi model) => _res.Create(model);
        public IEnumerable<NhaPhanPhoi> GetByUser(int maNguoiDung) => _res.GetByUser(maNguoiDung);
        public IEnumerable<NhaPhanPhoi> GetAll() => _res.GetAll();
        public bool Delete(int id) => _res.Delete(id);
    }
}
