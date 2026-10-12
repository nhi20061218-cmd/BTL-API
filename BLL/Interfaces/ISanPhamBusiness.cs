using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISanPhamBusiness
    {
        int Create(SanPham model);
        bool Update(SanPham model);
        bool Delete(int id);
        IEnumerable<SanPham> GetAll();
        object Search(int pageIndex, int pageSize, string? tenSanPham, string? loaiSanPham);
    }
}
