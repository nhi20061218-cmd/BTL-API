using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISieuThiRepository
    {
        int Create(SieuThi model);
        IEnumerable<SieuThi> GetByUser(int maNguoiDung);
        IEnumerable<SieuThi> GetAll();
        bool Delete(int id);
    }
}
