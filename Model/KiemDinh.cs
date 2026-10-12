using System;
using System.Collections.Generic;

namespace Model;

public partial class KiemDinh
{
    public int MaKiemDinh { get; set; }
    public int MaLoNongSan { get; set; }
    public int MaNguoiKiemDinh { get; set; }
    public string TenNguoiKiemDinh { get; set; } = string.Empty;
    public string KetQua { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
}
// Lớp chuyên dụng để hứng dữ liệu chữ ký số từ Frontend gửi lên
public class KiemDinhSignatureModel
{
    public int MaKiemDinh { get; set; }
    public string ChuKySoBase64 { get; set; } = string.Empty;
    public string KhoaCongKhai { get; set; } = string.Empty;
    public string? DuongDanBienBan { get; set; }
}