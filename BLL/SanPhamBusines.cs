using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
namespace BLL
{
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private readonly ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res) => _res = res;

        public int Create(SanPham model) => _res.Create(model);
        public bool Update(SanPham model) => _res.Update(model);
        public bool Delete(int id) => _res.Delete(id);
        public IEnumerable<SanPham> GetAll() => _res.GetAll();

        public object Search(int pageIndex, int pageSize, string? tenSanPham, string? loaiSanPham)
        {
            var data = _res.Search(pageIndex, pageSize, tenSanPham, loaiSanPham).ToList();
            int totalCount = data.Count > 0 ? data[0].RecordCount : 0;

            // Format trả về chuẩn hóa cho Frontend dễ lấy dữ liệu phân trang
            return new { TotalItems = totalCount, Data = data };
        }
    }
}
