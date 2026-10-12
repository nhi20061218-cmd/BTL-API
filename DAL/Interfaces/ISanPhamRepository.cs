using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISanPhamRepository
    {
        int Create(SanPham model);
        bool Update(SanPham model);
        bool Delete(int id);
        IEnumerable<SanPham> GetAll();
        IEnumerable<SanPham> Search(int pageIndex, int pageSize, string? tenSanPham, string? loaiSanPham);
    }
}
