using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVanChuyenBusiness
    {
        int Create(VanChuyen model);
        bool UpdateStatus(int maVanChuyen, string trangThaiMoi, int? nguoiDungId);
        VanChuyen GetById(int id);
        IEnumerable<VanChuyen> GetByLo(string maLoHang);
        object Search(int pageIndex, int pageSize, int? maNhaPhanPhoi, int? maSieuThiNhan, string? trangThai);
    }
}
