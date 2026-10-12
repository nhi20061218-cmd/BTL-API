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
    public class VanChuyenRepository : IVanChuyenRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public VanChuyenRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public int Create(VanChuyen model)
        {
            return _dbHelper.ExecuteScalar<int>("sp_vanchuyen_create", new
            {
                ma_lo_hang = model.MaLoHang,
                ma_nha_phan_phoi = model.MaNhaPhanPhoi,
                ma_kho_xuat = model.MaKhoXuat,
                ma_kho_nhap = model.MaKhoNhap,
                ma_sieu_thi_nhan = model.MaSieuThiNhan,
                thong_tin_xe = model.ThongTinXe,
                nguoi_dung_id = model.NguoiDungId
            }, CommandType.StoredProcedure);
        }

        public bool UpdateStatus(int maVanChuyen, string trangThaiMoi, int? nguoiDungId)
        {
            _dbHelper.Execute("sp_vanchuyen_update_status", new
            {
                ma_van_chuyen = maVanChuyen,
                trang_thai_moi = trangThaiMoi,
                nguoi_dung_id = nguoiDungId
            }, CommandType.StoredProcedure);
            return true;
        }

        public VanChuyen GetById(int id)
        {
            return _dbHelper.Query<VanChuyen>("sp_vanchuyen_get_by_id", new
            {
                ma_van_chuyen = id
            }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<VanChuyen> GetByLo(string maLoHang)
        {
            return _dbHelper.Query<VanChuyen>("sp_vanchuyen_get_by_lo", new
            {
                ma_lo_hang = maLoHang
            }, CommandType.StoredProcedure);
        }

        public IEnumerable<VanChuyen> Search(int pageIndex, int pageSize, int? maNhaPhanPhoi, int? maSieuThiNhan, string? trangThai)
        {
            return _dbHelper.Query<VanChuyen>("sp_vanchuyen_search", new
            {
                page_index = pageIndex,
                page_size = pageSize,
                ma_nha_phan_phoi = maNhaPhanPhoi,
                ma_sieu_thi_nhan = maSieuThiNhan,
                trang_thai = trangThai
            }, CommandType.StoredProcedure);
        }
    }
}
