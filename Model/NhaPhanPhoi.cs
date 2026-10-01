using System;
using System.Collections.Generic;

namespace Model;

public partial class NhaPhanPhoi
{
    public int MaNhaPhanPhoi { get; set; }

    public int MaNguoiDung { get; set; }

    public string TenCongTy { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<KhoHang> KhoHangs { get; set; } = new List<KhoHang>();

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ICollection<VanChuyen> VanChuyens { get; set; } = new List<VanChuyen>();
}
