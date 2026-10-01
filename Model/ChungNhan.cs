using System;
using System.Collections.Generic;

namespace Model;

public partial class ChungNhan
{
    public int MaChungNhan { get; set; }

    public int MaLoNongSan { get; set; }

    public string LoaiChungNhan { get; set; } = null!;

    public string SoChungNhan { get; set; } = null!;

    public string? NoiCap { get; set; }

    public DateOnly? NgayCap { get; set; }

    public DateOnly? HanSuDung { get; set; }

    public virtual LoNongSan MaLoNongSanNavigation { get; set; } = null!;
}
