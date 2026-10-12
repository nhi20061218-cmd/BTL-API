using System;
using System.Collections.Generic;

namespace Model;

public class SieuThi
{
    public int MaSieuThi { get; set; }
    public int MaNguoiDung { get; set; }
    public string TenCuaHang { get; set; } = string.Empty; // Đã đổi thành TenCuaHang
    public string? DiaChi { get; set; }
    public string? SoDienThoai { get; set; }
}
