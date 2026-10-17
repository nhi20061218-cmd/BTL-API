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
    public class NhatKyRepository : INhatKyRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public NhatKyRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public bool Create(NhatKy model)
        {
            _dbHelper.Execute("sp_nhatky_create", new
            {
                hanh_dong = model.HanhDong,
                doi_tuong = model.DoiTuong,
                ma_doi_tuong = model.MaDoiTuong,
                ma_nguoi_dung = model.MaNguoiDung,
                dia_chi_ip = model.DiaChiIP,
                ghi_chu = model.GhiChu
            }, System.Data.CommandType.StoredProcedure);

            return true;
        }

        public IEnumerable<NhatKy> Search(int pageIndex, int pageSize, string hanhDong, string maDoiTuong)
        {
            return _dbHelper.Query<NhatKy>("sp_nhatky_search", new
            {
                page_index = pageIndex,
                page_size = pageSize,
                hanh_dong = hanhDong,
                ma_doi_tuong = maDoiTuong
            }, System.Data.CommandType.StoredProcedure);


        }

        public IEnumerable<NhatKy> ThongKeQuet(string? maLoHang)
        {
            return _dbHelper.Query<NhatKy>("sp_nhatky_thong_ke_quet", new
            {
                ma_lo_hang = maLoHang
            }, CommandType.StoredProcedure).ToList();
        }
    }
}
