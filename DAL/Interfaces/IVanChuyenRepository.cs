using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVanChuyenRepository
    {
        int Create(VanChuyen model);
        bool UpdateStatus(int maVanChuyen, string trangThaiMoi, int? nguoiDungId);
        VanChuyen GetById(int id);
        IEnumerable<VanChuyen> GetByLo(string maLoHang);
        IEnumerable<VanChuyen> Search(int pageIndex, int pageSize, int? maNhaPhanPhoi, int? maSieuThiNhan, string? trangThai);
    }
}
