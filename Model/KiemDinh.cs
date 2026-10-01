using System;
using System.Collections.Generic;

namespace Model;

public partial class KiemDinh
{
    public int MaKiemDinh { get; set; }

    public int MaLoNongSan { get; set; }

    public int MaNguoiKiemDinh { get; set; }

    public DateTime NgayKiemDinh { get; set; }

    public string KetQua { get; set; } = null!;

    public string? GhiChu { get; set; }

    public byte[]? MaBaoCaoHash { get; set; }

    public DateTime NgayTao { get; set; }

    public virtual LoNongSan MaLoNongSanNavigation { get; set; } = null!;

    public virtual NguoiDung MaNguoiKiemDinhNavigation { get; set; } = null!;
}
