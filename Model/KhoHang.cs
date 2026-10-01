using System;
using System.Collections.Generic;

namespace Model;

public partial class KhoHang
{
    public int MaKhoHang { get; set; }

    public string TenKhoHang { get; set; } = null!;

    public string? DiaChi { get; set; }

    public int? MaNhaPhanPhoiQuanLy { get; set; }

    public decimal? SucChua { get; set; }

    public bool DaXoa { get; set; }

    public virtual ICollection<GiaoDichTonKho> GiaoDichTonKhoMaKhoHangNavigations { get; set; } = new List<GiaoDichTonKho>();

    public virtual ICollection<GiaoDichTonKho> GiaoDichTonKhoMaKhoLienQuanNavigations { get; set; } = new List<GiaoDichTonKho>();

    public virtual NhaPhanPhoi? MaNhaPhanPhoiQuanLyNavigation { get; set; }

    public virtual ICollection<VanChuyen> VanChuyenMaKhoNhapNavigations { get; set; } = new List<VanChuyen>();

    public virtual ICollection<VanChuyen> VanChuyenMaKhoXuatNavigations { get; set; } = new List<VanChuyen>();
}
