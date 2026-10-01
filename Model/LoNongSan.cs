using System;
using System.Collections.Generic;

namespace Model;

public partial class LoNongSan
{
    public int MaLoNongSan { get; set; }

    public string MaLoHang { get; set; } = null!;

    public int MaTrangTrai { get; set; }

    public int MaSanPham { get; set; }

    public DateOnly NgayThuHoach { get; set; }

    public DateOnly HanSuDung { get; set; }

    public decimal SoLuong { get; set; }

    public string DonViTinh { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public string? DuongDanMaQr { get; set; }

    public bool DaXoa { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<ChungNhan> ChungNhans { get; set; } = new List<ChungNhan>();

    public virtual ICollection<GiaoDichTonKho> GiaoDichTonKhos { get; set; } = new List<GiaoDichTonKho>();

    public virtual ICollection<KiemDinh> KiemDinhs { get; set; } = new List<KiemDinh>();

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;

    public virtual TrangTrai MaTrangTraiNavigation { get; set; } = null!;

    public virtual ICollection<VanChuyen> VanChuyens { get; set; } = new List<VanChuyen>();
}
