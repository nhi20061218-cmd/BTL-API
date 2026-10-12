using System;
using System.Collections.Generic;

namespace Model;

public class LoNongSan
{
    public int MaLoNongSan { get; set; }
    public string MaLoHang { get; set; } = string.Empty;
    public int MaTrangTrai { get; set; }
    public int MaSanPham { get; set; }

    // Các trường dùng để hiển thị (lấy từ bảng JOIN)
    public string? TenTrangTrai { get; set; }
    public string? TenSanPham { get; set; }
    public string? DonViTinh { get; set; }

    public DateTime NgayThuHoach { get; set; }
    public DateTime HanSuDung { get; set; }
    public decimal SoLuong { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public DateTime NgayTao { get; set; }

    public int RecordCount { get; set; }

}
