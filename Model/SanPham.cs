using System;
using System.Collections.Generic;

namespace Model;

public partial class SanPham
{
    public int MaSanPham { get; set; }
    public string TenSanPham { get; set; } = string.Empty;
    public string? LoaiSanPham { get; set; }

    // Mặc định đơn vị tính là 'kg' như trong cơ sở dữ liệu
    public string DonViTinh { get; set; } = "kg";

    // Dùng để lấy tổng số bản ghi khi phân trang
    public int RecordCount { get; set; }
}
