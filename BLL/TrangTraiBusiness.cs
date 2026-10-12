using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TrangTraiBusiness : ITrangTraiBusiness
    {
        private readonly ITrangTraiRepository _res;
        public TrangTraiBusiness(ITrangTraiRepository res) => _res = res;

        public int Create(TrangTrai model)
        {
            return _res.Create(model);
        }

        public object Search(int pageIndex, int pageSize, string? tenTrangTrai, int? maChuTrangTrai)
        {
            var data = _res.Search(pageIndex, pageSize, tenTrangTrai, maChuTrangTrai).ToList();
            int totalCount = data.Count > 0 ? data[0].RecordCount : 0;
            return new
            {
                TotalItems = totalCount,
                Data = data
            };
        }
        public bool Update(TrangTrai model)
        {
            return _res.Update(model);
        }

        public bool Delete(int maTrangTrai)
        {
            return _res.Delete(maTrangTrai);
        }
    }
}
