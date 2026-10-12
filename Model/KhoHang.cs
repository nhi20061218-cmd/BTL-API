using System;
using System.Collections.Generic;

namespace Model;

public class KhoHang
{
    public int MaKhoHang { get; set; }
    public int? MaNhaPhanPhoi { get; set; }
    public string TenKhoHang { get; set; } = string.Empty;
    public string? DiaChi { get; set; }
    public decimal? SucChua { get; set; }
}
