using System;
using System.Collections.Generic;

namespace Model;

public partial class SanPham
{
    public int MaSanPham { get; set; }

    public int MaDanhMuc { get; set; }

    public string TenSanPham { get; set; } = null!;

    public string DonViTinh { get; set; } = null!;

    public string? MoTa { get; set; }

    public bool DaXoa { get; set; }

    public DateTime NgayTao { get; set; }

    public virtual ICollection<LoNongSan> LoNongSans { get; set; } = new List<LoNongSan>();

    public virtual DanhMuc MaDanhMucNavigation { get; set; } = null!;
}
