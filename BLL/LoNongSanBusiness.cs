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
    public class LoNongSanBusiness : ILoNongSanBusiness
    {
        private readonly ILoNongSanRepository _res;
        public LoNongSanBusiness(ILoNongSanRepository res) => _res = res;

        public string Create(LoNongSan model, int nguoiDungId)
        {
            return _res.Create(model, nguoiDungId);
        }

        public object Search(int pageIndex, int pageSize, string? trangThai, int? maTrangTrai)
        {
            var data = _res.Search(pageIndex, pageSize, trangThai, maTrangTrai).ToList();
            int totalCount = data.Count > 0 ? data[0].RecordCount : 0;
            return new
            {
                TotalItems = totalCount,
                Data = data
            };
        }

        public bool Update(LoNongSan model)
        {
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool UpdateStatus(int maLoNongSan, string trangThaiMoi, int? nguoiDungId)
        {
            return _res.UpdateStatus(maLoNongSan, trangThaiMoi, nguoiDungId);
        }

        public int MarkExpired()
        {
            return _res.MarkExpired();
        }
    }
}
