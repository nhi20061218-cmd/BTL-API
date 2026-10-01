using System;
using System.Collections.Generic;

namespace Model;

public partial class VanChuyen
{
    public int MaVanChuyen { get; set; }

    public int MaLoNongSan { get; set; }

    public int MaNhaPhanPhoi { get; set; }

    public int? MaKhoXuat { get; set; }

    public int? MaKhoNhap { get; set; }

    public int? MaSieuThiNhan { get; set; }

    public string? ThongTinXe { get; set; }

    public string? ThongTinTuyenDuong { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateTime? NgayLayHang { get; set; }

    public DateTime? NgayGiaoHang { get; set; }

    public DateTime NgayTao { get; set; }

    public virtual KhoHang? MaKhoNhapNavigation { get; set; }

    public virtual KhoHang? MaKhoXuatNavigation { get; set; }

    public virtual LoNongSan MaLoNongSanNavigation { get; set; } = null!;

    public virtual NhaPhanPhoi MaNhaPhanPhoiNavigation { get; set; } = null!;

    public virtual SieuThi? MaSieuThiNhanNavigation { get; set; }
}
