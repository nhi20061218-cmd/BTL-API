using System;
using System.Collections.Generic;

namespace Model;

public partial class NhatKyHeThong
{
    public long MaNhatKy { get; set; }

    public string TenBang { get; set; } = null!;

    public int MaBanGhi { get; set; }

    public string LoaiHanhDong { get; set; } = null!;

    public string? GiaTriCu { get; set; }

    public string? GiaTriMoi { get; set; }

    public int? MaNguoiThayDoi { get; set; }

    public DateTime NgayThayDoi { get; set; }
}
