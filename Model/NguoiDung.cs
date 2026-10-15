using System;
using System.Collections.Generic;

namespace Model;


public class NguoiDung
{
    public int MaNguoiDung { get; set; }
    public string TenDangNhap { get; set; } = string.Empty;
    public string MatKhauHash { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? SoDienThoai { get; set; }
    public int MaVaiTro { get; set; }
    public string? VaiTro { get; set; } // Hứng tên vai trò từ lệnh JOIN
    public bool HoatDong { get; set; }
    public DateTime NgayTao { get; set; }

    // Các trường phụ trợ không lưu trong DB
    public string? Token { get; set; }
    public int RecordCount { get; set; }
}


