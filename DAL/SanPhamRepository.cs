using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public int Create(SanPham model)
        {
            return _dbHelper.ExecuteScalar<int>("sp_sanpham_create", new
            {
                ten_san_pham = model.TenSanPham,
                loai_san_pham = model.LoaiSanPham,
                don_vi_tinh = model.DonViTinh
            }, CommandType.StoredProcedure);
        }

        public bool Update(SanPham model)
        {
            _dbHelper.Execute("sp_sanpham_update", new
            {
                ma_san_pham = model.MaSanPham,
                ten_san_pham = model.TenSanPham,
                loai_san_pham = model.LoaiSanPham,
                don_vi_tinh = model.DonViTinh
            }, CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int id)
        {
            _dbHelper.Execute("sp_sanpham_delete", new { ma_san_pham = id }, CommandType.StoredProcedure);
            return true;
        }

        public IEnumerable<SanPham> GetAll()
        {
            return _dbHelper.Query<SanPham>("sp_sanpham_get_all", null, CommandType.StoredProcedure);
        }

        public IEnumerable<SanPham> Search(int pageIndex, int pageSize, string? tenSanPham, string? loaiSanPham)
        {
            return _dbHelper.Query<SanPham>("sp_sanpham_search", new
            {
                page_index = pageIndex,
                page_size = pageSize,
                ten_san_pham = tenSanPham,
                loai_san_pham = loaiSanPham
            }, CommandType.StoredProcedure);
        }
    }
}
