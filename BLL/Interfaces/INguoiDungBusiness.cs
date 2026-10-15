using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INguoiDungBusiness
    {
        // Nhóm cho API_Auth
        NguoiDung Authenticate(LoginRequestModel request);
        bool Register(RegisterRequestModel request);

        // BỔ SUNG NHÓM API_Admin
        NguoiDung GetById(int maNguoiDung);
        IEnumerable<NguoiDung> Search(int pageIndex, int pageSize, string? hoTen, string? tenDangNhap, int? maVaiTro);
        bool Update(NguoiDung model);
        bool SetRole(int maNguoiDung, int maVaiTro);
        bool SetActive(int maNguoiDung, bool hoatDong);
        bool SetPassword(int maNguoiDung, string matKhauMoi);
        bool Delete(int maNguoiDung);
    }
}
