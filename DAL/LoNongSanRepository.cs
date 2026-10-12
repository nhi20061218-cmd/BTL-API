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
    public class LoNongSanRepository : ILoNongSanRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public LoNongSanRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public string Create(LoNongSan model, int nguoiDungId)
        {
            return _dbHelper.ExecuteScalar<string>("sp_lonongsan_create", new
            {
                ma_trang_trai = model.MaTrangTrai,
                ma_san_pham = model.MaSanPham,
                ngay_thu_hoach = model.NgayThuHoach,
                han_su_dung = model.HanSuDung,
                so_luong = model.SoLuong,
                nguoi_dung_id = nguoiDungId
            }, CommandType.StoredProcedure);
        }

        public IEnumerable<LoNongSan> Search(int pageIndex, int pageSize, string? trangThai, int? maTrangTrai)
        {
            return _dbHelper.Query<LoNongSan>("sp_lonongsan_search", new
            {
                page_index = pageIndex,
                page_size = pageSize,
                trang_thai = trangThai,
                ma_trang_trai = maTrangTrai
            }, CommandType.StoredProcedure);
        }

        public bool Update(LoNongSan model)
        {
            // Theo SQL, sp_lonongsan_update chỉ nhận 3 tham số: mã lô, số lượng và hạn sử dụng
            _dbHelper.Execute("sp_lonongsan_update", new
            {
                ma_lo_nong_san = model.MaLoNongSan,
                so_luong = model.SoLuong,
                han_su_dung = model.HanSuDung
            }, CommandType.StoredProcedure);

            return true;
        }

        public bool Delete(int id)
        {
            _dbHelper.Execute("sp_lonongsan_delete", new
            {
                ma_lo_nong_san = id
            }, CommandType.StoredProcedure);

            return true;
        }
        public bool UpdateStatus(int maLoNongSan, string trangThaiMoi, int? nguoiDungId)
        {
            _dbHelper.Execute("sp_lonongsan_update_status", new
            {
                ma_lo_nong_san = maLoNongSan,
                trang_thai_moi = trangThaiMoi,
                nguoi_dung_id = nguoiDungId
            }, CommandType.StoredProcedure);

            return true;
        }

        public int MarkExpired()
        {
            // SP này trả về SELECT @@ROWCOUNT AS SoLoHetHan, nên ta dùng QueryFirstOrDefault<int> để lấy con số này
            return _dbHelper.QueryFirstOrDefault<int>("sp_lonongsan_mark_expired", null, CommandType.StoredProcedure);
        }
    }
}
