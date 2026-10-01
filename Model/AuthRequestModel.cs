using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginRequestModel
    {
        [Required] public string TenDangNhap { get; set; } = string.Empty;
        [Required] public string MatKhau { get; set; } = string.Empty;
    }

    public class RegisterRequestModel
    {
        [Required] public string TenDangNhap { get; set; } = string.Empty;
        [Required] public string MatKhau { get; set; } = string.Empty;
        [Required] public string HoTen { get; set; } = string.Empty;
        [Required] public string Email { get; set; } = string.Empty;
        public string? SoDienThoai { get; set; }
        [Required] public int MaVaiTro { get; set; } // Người dùng phải truyền ID vai trò (VD: 1, 2)
    }
}
