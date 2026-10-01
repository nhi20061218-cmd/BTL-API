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
            _dbHelper.Execute("SP_NguoiDung_ThemMoi", new
            {
                TenDangNhap = model.TenDangNhap,
                MatKhauHash = model.MatKhauHash,
                HoTen = model.HoTen,
                Email = model.Email,
                SoDienThoai = model.SoDienThoai,
                MaVaiTro = model.MaVaiTro
            }, CommandType.StoredProcedure);
            return true;
        }

        public NguoiDung GetByUsername(string username)
        {
            return _dbHelper.QueryFirstOrDefault<NguoiDung>(
                "SP_NguoiDung_LayTheoTaiKhoan",
                new { TenDangNhap = username },
                CommandType.StoredProcedure);
        }
    }
}
