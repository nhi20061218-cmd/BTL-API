using DAL.Helper.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public NguoiDungRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public NguoiDung GetByUsername(string tenDangNhap)
        {
            return _dbHelper.Query<NguoiDung>("sp_nguoidung_get_by_username", new { ten_dang_nhap = tenDangNhap }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool Create(NguoiDung model)
        {
            _dbHelper.Execute("sp_nguoidung_create", new
            {
                ten_dang_nhap = model.TenDangNhap,
                mat_khau_hash = model.MatKhauHash,
                ho_ten = model.HoTen,
                email = model.Email,
                so_dien_thoai = model.SoDienThoai,
                ma_vai_tro = model.MaVaiTro
            }, CommandType.StoredProcedure);
            return true;
        }

        public NguoiDung GetById(int maNguoiDung)
        {
            return _dbHelper.Query<NguoiDung>("sp_nguoidung_get_by_id", new { ma_nguoi_dung = maNguoiDung }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<NguoiDung> Search(int pageIndex, int pageSize, string? hoTen, string? tenDangNhap, int? maVaiTro)
        {
            return _dbHelper.Query<NguoiDung>("sp_nguoidung_search", new
            {
                page_index = pageIndex,
                page_size = pageSize,
                ho_ten = hoTen,
                ten_dang_nhap = tenDangNhap,
                ma_vai_tro = maVaiTro
            }, CommandType.StoredProcedure);
        }

        public bool Update(NguoiDung model)
        {
            _dbHelper.Execute("sp_nguoidung_update", new { ma_nguoi_dung = model.MaNguoiDung, ho_ten = model.HoTen, email = model.Email, so_dien_thoai = model.SoDienThoai }, CommandType.StoredProcedure);
            return true;
        }

        public bool SetRole(int maNguoiDung, int maVaiTro)
        {
            _dbHelper.Execute("sp_nguoidung_set_role", new { ma_nguoi_dung = maNguoiDung, ma_vai_tro = maVaiTro }, CommandType.StoredProcedure);
            return true;
        }

        public bool SetActive(int maNguoiDung, bool hoatDong)
        {
            _dbHelper.Execute("sp_nguoidung_set_active", new { ma_nguoi_dung = maNguoiDung, hoat_dong = hoatDong }, CommandType.StoredProcedure);
            return true;
        }

        public bool SetPassword(int maNguoiDung, string matKhauHash)
        {
            _dbHelper.Execute("sp_nguoidung_set_password", new { ma_nguoi_dung = maNguoiDung, mat_khau_hash = matKhauHash }, CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int maNguoiDung)
        {
            _dbHelper.Execute("sp_nguoidung_delete", new { ma_nguoi_dung = maNguoiDung }, CommandType.StoredProcedure);
            return true;
        }
    }
}
