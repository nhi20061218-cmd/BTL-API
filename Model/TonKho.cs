using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TonKho
    {
        public int MaKhoHang { get; set; }
        public string? TenKhoHang { get; set; }
        public string MaLoHang { get; set; } = string.Empty;
        public string TenSanPham { get; set; } = string.Empty;
        public decimal SoLuong { get; set; }
        public DateTime HanSuDung { get; set; }

        // Trường này dành cho hàm lấy tồn kho bình thường
        public DateTime? NgayNhap { get; set; }

        // 2 Trường này dành cho hàm cảnh báo hết hạn
        public int? SoNgayConLai { get; set; }
        public string? MucDo { get; set; }
    }
}
