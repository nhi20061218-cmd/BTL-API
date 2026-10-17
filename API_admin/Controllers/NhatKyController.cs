using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BLL.Interfaces.INhatKyHeThongBusiness;

namespace API_admin.Controllers
{
    // Bắt buộc phải là Admin mới được xem log hệ thống
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class NhatKyController : ControllerBase
    {
        private readonly INhatKyBusiness _nhatKyBusiness;

        public NhatKyController(INhatKyBusiness nhatKyBusiness)
        {
            _nhatKyBusiness = nhatKyBusiness;
        }

        // HÀM TÌM KIẾM CÓ PHÂN TRANG VÀ LỌC THEO ĐỐI TƯỢNG
        [HttpGet("search")]
        public IActionResult Search([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string hanhDong = null, [FromQuery] string maDoiTuong = null)
        {
            try
            {
                // Gọi xuống BLL, truyền các tham số lấy từ đường dẫn URL (Query String)
                var data = _nhatKyBusiness.Search(pageIndex, pageSize, hanhDong, maDoiTuong);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        // 2. API Thống kê số lần quét mã QR của các lô nông sản
        [HttpGet("thong-ke-quet")]
        public IActionResult GetThongKeQuet([FromQuery] string? maLoHang = null)
        {
            try
            {
                var data = _nhatKyBusiness.ThongKeQuet(maLoHang);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

