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
    public class VanChuyenBusiness : IVanChuyenBusiness
    {
        private readonly IVanChuyenRepository _res;
        public VanChuyenBusiness(IVanChuyenRepository res) => _res = res;

        public int Create(VanChuyen model) => _res.Create(model);

        public bool UpdateStatus(int maVanChuyen, string trangThaiMoi, int? nguoiDungId)
            => _res.UpdateStatus(maVanChuyen, trangThaiMoi, nguoiDungId);

        public VanChuyen GetById(int id) => _res.GetById(id);

        public IEnumerable<VanChuyen> GetByLo(string maLoHang) => _res.GetByLo(maLoHang);

        public object Search(int pageIndex, int pageSize, int? maNhaPhanPhoi, int? maSieuThiNhan, string? trangThai)
        {
            var data = _res.Search(pageIndex, pageSize, maNhaPhanPhoi, maSieuThiNhan, trangThai).ToList();
            int totalCount = data.Count > 0 ? data[0].RecordCount : 0;
            return new { TotalItems = totalCount, Data = data };
        }
    }
}
