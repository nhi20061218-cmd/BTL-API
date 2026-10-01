using System;
using System.Collections.Generic;

namespace Model;

public partial class TrangTrai
{
    public int MaTrangTrai { get; set; }

    public int MaChuTrangTrai { get; set; }

    public string TenTrangTrai { get; set; } = null!;

    public string? DiaChi { get; set; }

    public decimal? DienTichHecta { get; set; }

    public bool DaXoa { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<LoNongSan> LoNongSans { get; set; } = new List<LoNongSan>();

    public virtual NguoiDung MaChuTrangTraiNavigation { get; set; } = null!;
}
