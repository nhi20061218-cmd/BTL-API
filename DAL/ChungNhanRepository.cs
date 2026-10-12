using DAL.Helper.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public class ChungNhanRepository : IChungNhanRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public ChungNhanRepository(IDatabaseHelper dbHelper) => _dbHelper = dbHelper;

        public bool Create(ChungNhan model)
        {
            _dbHelper.Execute("sp_chungnhan_create", new
            {
                ma_lo_nong_san = model.MaLoNongSan,
                loai_chung_nhan = model.LoaiChungNhan,
                so_chung_nhan = model.SoChungNhan,
                noi_cap = model.NoiCap,
                ngay_cap = model.NgayCap,
                han_su_dung = model.HanSuDung
            }, CommandType.StoredProcedure);

            return true;
        }

        public IEnumerable<ChungNhan> GetByLo(int maLoNongSan)
        {
            return _dbHelper.Query<ChungNhan>("sp_chungnhan_get_by_lo", new
            {
                ma_lo_nong_san = maLoNongSan
            }, CommandType.StoredProcedure);
        }
    }
}