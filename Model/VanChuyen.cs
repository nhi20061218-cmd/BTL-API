using System;
using System.Collections.Generic;

namespace Model;


    public class VanChuyen
    {
        public int MaVanChuyen { get; set; }
        public string MaLoHang { get; set; } = string.Empty;
        public string TenSanPham { get; set; } = string.Empty;
        public decimal SoLuong { get; set; }
        public DateTime HanSuDung { get; set; }
        public int MaNhaPhanPhoi { get; set; }
        public string? DaiLy { get; set; } // Lấy tên NPP khi JOIN

        public int? MaKhoXuat { get; set; }
        public string? TuKho { get; set; } // Tên kho xuất khi JOIN

        public int? MaKhoNhap { get; set; }
        public string? DenKho { get; set; } // Tên kho nhập khi JOIN

        public int? MaSieuThiNhan { get; set; }
        public string? DenSieuThi { get; set; } // Tên siêu thị nhận khi JOIN

        public string? ThongTinXe { get; set; }
        public string TrangThai { get; set; } = "Picked";

        public DateTime? NgayLayHang { get; set; }
        public DateTime? NgayGiaoHang { get; set; }

        public int? NguoiDungId { get; set; } // Dùng để truyền xuống SP ghi Nhật ký
        public int RecordCount { get; set; } // Dùng cho phân trang
    }

