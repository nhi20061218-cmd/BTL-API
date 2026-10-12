using System;
using System.Collections.Generic;

namespace Model;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }
    public string TenDangNhap { get; set; } = string.Empty;
    public string MatKhauHash { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? SoDienThoai { get; set; }
    public int MaVaiTro { get; set; }

    public bool HoatDong { get; set; }
    public DateTime NgayTao { get; set; }

    public string? Token { get; set; }
    public string VaiTro { get; set; } = string.Empty;
}
