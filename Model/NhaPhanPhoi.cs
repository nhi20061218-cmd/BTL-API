using System;
using System.Collections.Generic;

namespace Model;

public partial class NhaPhanPhoi
{
    public int MaNhaPhanPhoi { get; set; }
    public int MaNguoiDung { get; set; }
    public string TenCongTy { get; set; } = string.Empty;
    public string? DiaChi { get; set; }
    public string? SoDienThoai { get; set; }
}
