using System;
using System.Collections.Generic;

namespace Model;

public class NhatKy
{
    public int MaNhatKy { get; set; }
    public string? HanhDong { get; set; }
    public string? DoiTuong { get; set; }
    public string? MaDoiTuong { get; set; }
    public int? MaNguoiDung { get; set; }
    public string? DiaChiIP { get; set; }
    public string? GhiChu { get; set; }
    public DateTime NgayGio { get; set; }
    public int RecordCount { get; set; } // Phục vụ cho hàm Search phân trang
                                         // (Do SP sp_nhatky_thong_ke_quet select ra 3 cột: MaLoHang, SoLanQuet, LanQuetCuoi)
    public string? MaLoHang { get; set; }
    public int SoLanQuet { get; set; }
    public DateTime? LanQuetCuoi { get; set; }
}
