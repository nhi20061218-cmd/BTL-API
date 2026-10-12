using DAL.Helper.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
namespace DAL
{
    public class KhoHangRepository : IKhoHangRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public KhoHangRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public int Create(KhoHang model)
        {
            return _dbHelper.ExecuteScalar<int>("sp_khohang_create", new
            {
                ma_nha_phan_phoi = model.MaNhaPhanPhoi,
                ten_kho_hang = model.TenKhoHang,
                dia_chi = model.DiaChi,
                suc_chua = model.SucChua
            }, CommandType.StoredProcedure);
        }

        public bool Update(KhoHang model)
        {
            _dbHelper.Execute("sp_khohang_update", new
            {
                ma_kho_hang = model.MaKhoHang,
                ten_kho_hang = model.TenKhoHang,
                dia_chi = model.DiaChi,
                suc_chua = model.SucChua
            }, CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int id)
        {
            _dbHelper.Execute("sp_khohang_delete", new { ma_kho_hang = id }, CommandType.StoredProcedure);
            return true;
        }

        public KhoHang GetById(int id)
        {
            return _dbHelper.Query<KhoHang>("sp_khohang_get_by_id", new
            {
                ma_kho_hang = id
            }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<KhoHang> GetAll(int? maNhaPhanPhoi)
        {
            return _dbHelper.Query<KhoHang>("sp_khohang_get_all", new
            {
                ma_nha_phan_phoi = maNhaPhanPhoi
            }, CommandType.StoredProcedure);
        }
    }
}
