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
    public class SieuThiRepository : ISieuThiRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public SieuThiRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public int Create(SieuThi model)
        {
            return _dbHelper.ExecuteScalar<int>("sp_sieuthi_create", new
            {
                ma_nguoi_dung = model.MaNguoiDung,
                ten_cua_hang = model.TenCuaHang, // Map chuẩn xác với biến trong SQL
                dia_chi = model.DiaChi,
                so_dien_thoai = model.SoDienThoai
            }, CommandType.StoredProcedure);
        }

        public IEnumerable<SieuThi> GetByUser(int maNguoiDung)
        {
            return _dbHelper.Query<SieuThi>("sp_sieuthi_get_by_user", new
            {
                ma_nguoi_dung = maNguoiDung
            }, CommandType.StoredProcedure);
        }

        public IEnumerable<SieuThi> GetAll()
        {
            return _dbHelper.Query<SieuThi>("sp_sieuthi_get_all", null, CommandType.StoredProcedure);
        }

        public bool Delete(int id)
        {
            _dbHelper.Execute("sp_sieuthi_delete", new { ma_sieu_thi = id }, CommandType.StoredProcedure);
            return true;
        }
    }
}
