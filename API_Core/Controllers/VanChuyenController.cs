using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VanChuyenController : ControllerBase
    {
        private readonly IVanChuyenBusiness _vanChuyenBusiness;

        public VanChuyenController(IVanChuyenBusiness vanChuyenBusiness)
        {
            _vanChuyenBusiness = vanChuyenBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] VanChuyen request)
        {
            int newId = _vanChuyenBusiness.Create(request);
            return Ok(new { message = "Lập lệnh vận chuyển thành công!", maVanChuyen = newId });
        }

        // API này dùng để tài xế bấm nút "Đang giao" (InTransit) hoặc "Đã giao" (Delivered)
        [HttpPatch("update-status/{id}")]
        public IActionResult UpdateStatus(int id, [FromQuery] string trangThaiMoi, [FromQuery] int? nguoiDungId = null)
        {
            _vanChuyenBusiness.UpdateStatus(id, trangThaiMoi, nguoiDungId);
            return Ok(new { message = $"Cập nhật trạng thái thành '{trangThaiMoi}' thành công!" });
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _vanChuyenBusiness.GetById(id);
            if (result == null) return NotFound(new { message = "Không tìm thấy thông tin vận chuyển." });
            return Ok(result);
        }

        // Lấy lịch sử hành trình của 1 lô nông sản cụ thể
        [HttpGet("get-by-lo/{maLoHang}")]
        public IActionResult GetByLo(string maLoHang)
        {
            return Ok(_vanChuyenBusiness.GetByLo(maLoHang));
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] int? maNhaPhanPhoi = null, [FromQuery] int? maSieuThiNhan = null, [FromQuery] string? trangThai = null)
        {
            return Ok(_vanChuyenBusiness.Search(page, pageSize, maNhaPhanPhoi, maSieuThiNhan, trangThai));
        }
    }
}

