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
    public class NhaPhanPhoiRepository : INhaPhanPhoiRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public NhaPhanPhoiRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public int Create(NhaPhanPhoi model)
        {
            return _dbHelper.ExecuteScalar<int>("sp_nhaphanphoi_create", new
            {
                ma_nguoi_dung = model.MaNguoiDung,
                ten_cong_ty = model.TenCongTy,
                dia_chi = model.DiaChi,
                so_dien_thoai = model.SoDienThoai
            }, CommandType.StoredProcedure);
        }

        public IEnumerable<NhaPhanPhoi> GetByUser(int maNguoiDung)
        {
            return _dbHelper.Query<NhaPhanPhoi>("sp_nhaphanphoi_get_by_user", new
            {
                ma_nguoi_dung = maNguoiDung
            }, CommandType.StoredProcedure); 
        }

        public IEnumerable<NhaPhanPhoi> GetAll()
        {
            return _dbHelper.Query<NhaPhanPhoi>("sp_nhaphanphoi_get_all", null, CommandType.StoredProcedure);
        }

        public bool Delete(int id)
        {
            _dbHelper.Execute("sp_nhaphanphoi_delete", new { ma_nha_phan_phoi = id }, CommandType.StoredProcedure);
            return true;
        }
    }
}
