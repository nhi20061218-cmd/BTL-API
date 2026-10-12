using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Model;
using System.Data;

namespace DAL
{
    public class TrangTraiRepository : ITrangTraiRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public TrangTraiRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public int Create(TrangTrai model)
        {
            var result = _dbHelper.ExecuteScalar<int>("sp_trangtrai_create", new
            {
                ma_chu_trang_trai = model.MaChuTrangTrai,
                ten_trang_trai = model.TenTrangTrai,
                dia_chi = model.DiaChi,
                dien_tich_hecta = model.DienTichHecta
            }, CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<TrangTrai> Search(int pageIndex, int pageSize, string? tenTrangTrai, int? maChuTrangTrai)
        {
            return _dbHelper.Query<TrangTrai>("sp_trangtrai_search", new
            {
                page_index = pageIndex,
                page_size = pageSize,
                ten_trang_trai = tenTrangTrai,
                ma_chu_trang_trai = maChuTrangTrai
            }, CommandType.StoredProcedure);
        }

        public bool Update(TrangTrai model)
        {
            _dbHelper.Execute("sp_trangtrai_update", new
            {
                ma_trang_trai = model.MaTrangTrai,
                ten_trang_trai = model.TenTrangTrai,
                dia_chi = model.DiaChi,
                dien_tich_hecta = model.DienTichHecta
            }, CommandType.StoredProcedure);

            return true;
        }

        public bool Delete(int maTrangTrai)
        {
            _dbHelper.Execute("sp_trangtrai_delete", new
            {
                ma_trang_trai = maTrangTrai
            }, CommandType.StoredProcedure);

            return true;
        }
    }
}
