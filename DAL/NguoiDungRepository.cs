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

        public NguoiDung GetByUsername(string username)
        {
            // Gọi tên SP mới và đổi biến sang chuẩn snake_case
            return _dbHelper.QueryFirstOrDefault<NguoiDung>(
                "sp_nguoidung_get_by_username",
                new { ten_dang_nhap = username },
                CommandType.StoredProcedure);
        }
    }
}
