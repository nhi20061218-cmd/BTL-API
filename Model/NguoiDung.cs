using System;
using System.Collections.Generic;

namespace Model;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhauHash { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public int MaVaiTro { get; set; }

    public bool TrangThaiHoatDong { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<GiaoDichTonKho> GiaoDichTonKhos { get; set; } = new List<GiaoDichTonKho>();

    public virtual ICollection<KiemDinh> KiemDinhs { get; set; } = new List<KiemDinh>();

    public virtual VaiTro MaVaiTroNavigation { get; set; } = null!;

    public virtual ICollection<NhaPhanPhoi> NhaPhanPhois { get; set; } = new List<NhaPhanPhoi>();

    public virtual ICollection<SieuThi> SieuThis { get; set; } = new List<SieuThi>();

    public virtual ICollection<TrangTrai> TrangTrais { get; set; } = new List<TrangTrai>();
    public string? Token { get; set; }
    public string VaiTro { get; set; } = string.Empty;
}
