using System;
using System.Collections.Generic;

namespace Model;

public partial class TrangTrai
{
    public int MaTrangTrai { get; set; }
    public int MaChuTrangTrai { get; set; }
    public string TenTrangTrai { get; set; } = string.Empty;
    public string? DiaChi { get; set; }
    public decimal? DienTichHecta { get; set; }
    public DateTime NgayTao { get; set; }

    // Thuộc tính để hứng tổng số dòng khi phân trang
    public int RecordCount { get; set; }
}
