using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INguoiDungRepository
    {
        // Nhóm dùng cho API_Auth
        NguoiDung GetByUsername(string tenDangNhap);
        bool Create(NguoiDung model);

        // Nhóm dùng cho API_Admin
        NguoiDung GetById(int maNguoiDung);
        IEnumerable<NguoiDung> Search(int pageIndex, int pageSize, string? hoTen, string? tenDangNhap, int? maVaiTro);
        bool Update(NguoiDung model);
        bool SetRole(int maNguoiDung, int maVaiTro);
        bool SetActive(int maNguoiDung, bool hoatDong);
        bool SetPassword(int maNguoiDung, string matKhauHash);
        bool Delete(int maNguoiDung);
    }
}
