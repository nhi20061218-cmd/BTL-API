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
    public class TonKhoRepository : ITonKhoRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public TonKhoRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public IEnumerable<TonKho> GetByKho(int? maKhoHang)
        {
            return _dbHelper.Query<TonKho>("sp_tonkho_get", new
            {
                ma_kho_hang = maKhoHang
            }, CommandType.StoredProcedure);
        }

        public IEnumerable<TonKho> GetHetHan(int soNgay)
        {
            return _dbHelper.Query<TonKho>("sp_tonkho_het_han", new
            {
                so_ngay = soNgay
            }, CommandType.StoredProcedure);
        }
    }
}
