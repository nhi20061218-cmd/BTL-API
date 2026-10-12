using System;
using System.Collections.Generic;

namespace Model;

public partial class ChungNhan
{
    public int MaChungNhan { get; set; }
    public int MaLoNongSan { get; set; }
    public string LoaiChungNhan { get; set; } = string.Empty;
    public string SoChungNhan { get; set; } = string.Empty;
    public string? NoiCap { get; set; }
    public DateTime? NgayCap { get; set; }
    public DateTime? HanSuDung { get; set; }
}
