using System;
using System.Collections.Generic;

namespace Model;

public partial class GiaoDichTonKho
{
    public int MaGiaoDich { get; set; }

    public int MaLoNongSan { get; set; }

    public int MaKhoHang { get; set; }

    public string LoaiGiaoDich { get; set; } = null!;

    public decimal SoLuong { get; set; }

    public int? MaKhoLienQuan { get; set; }

    public int MaNguoiTao { get; set; }

    public DateTime NgayGiaoDich { get; set; }

    public virtual KhoHang MaKhoHangNavigation { get; set; } = null!;

    public virtual KhoHang? MaKhoLienQuanNavigation { get; set; }

    public virtual LoNongSan MaLoNongSanNavigation { get; set; } = null!;

    public virtual NguoiDung MaNguoiTaoNavigation { get; set; } = null!;
}
