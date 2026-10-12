using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISieuThiBusiness
    {
        int Create(SieuThi model);
        IEnumerable<SieuThi> GetByUser(int maNguoiDung);
        IEnumerable<SieuThi> GetAll();
        bool Delete(int id);
    }
}
