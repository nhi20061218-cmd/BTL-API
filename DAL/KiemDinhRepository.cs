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
    public class KiemDinhRepository : IKiemDinhRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public KiemDinhRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public int Create(KiemDinh model)
        {
            return _dbHelper.ExecuteScalar<int>("sp_kiemdinh_create", new
            {
                ma_lo_nong_san = model.MaLoNongSan,
                ma_nguoi_kiem_dinh = model.MaNguoiKiemDinh,
                ten_nguoi_kiem_dinh = model.TenNguoiKiemDinh,
                ket_qua = model.KetQua,
                ghi_chu = model.GhiChu
            }, CommandType.StoredProcedure);
        }

        public IEnumerable<dynamic> GetByLo(int maLoNongSan)
        {
            return _dbHelper.Query<dynamic>("sp_kiemdinh_get_by_lo", new { ma_lo_nong_san = maLoNongSan }, CommandType.StoredProcedure);
        }

        public dynamic GetDataToSign(int maKiemDinh)
        {
            return _dbHelper.Query<dynamic>("sp_kiemdinh_get_data_to_sign", new { ma_kiem_dinh = maKiemDinh }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool SaveSignature(int maKiemDinh, byte[] chuKySo, string khoaCongKhai, string? duongDan)
        {
            _dbHelper.Execute("sp_kiemdinh_save_signature", new
            {
                ma_kiem_dinh = maKiemDinh,
                chu_ky_so = chuKySo,
                khoa_cong_khai = khoaCongKhai,
                duong_dan_bien_ban = duongDan
            }, CommandType.StoredProcedure);
            return true;
        }

        public dynamic Verify(int maKiemDinh)
        {
            return _dbHelper.Query<dynamic>("sp_kiemdinh_verify", new { ma_kiem_dinh = maKiemDinh }, CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
