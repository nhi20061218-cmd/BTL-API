using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Batch.Controllers
{
    [Authorize(Roles = "Farmer,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoNongSanController : ControllerBase
    {
        private readonly ILoNongSanBusiness _loNongSanBusiness;

        public LoNongSanController(ILoNongSanBusiness loNongSanBusiness)
        {
            _loNongSanBusiness = loNongSanBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] LoNongSan request, [FromQuery] int nguoiDungId)
        {
            var maLo = _loNongSanBusiness.Create(request, nguoiDungId);
            return Ok(new { message = "Đăng ký lô nông sản thành công!", maLoHang = maLo });
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? trangThai = null, [FromQuery] int? maTrangTrai = null)
        {
            var result = _loNongSanBusiness.Search(page, pageSize, trangThai, maTrangTrai);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] LoNongSan request)
        {
            _loNongSanBusiness.Update(request);
            return Ok(new { message = "Cập nhật lô nông sản thành công!" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _loNongSanBusiness.Delete(id);
            return Ok(new { message = $"Xóa thành công lô nông sản số {id}!" });
        }

        [HttpPut("update-status/{id}")]
        public IActionResult UpdateStatus(int id, [FromQuery] string trangThaiMoi, [FromQuery] int? nguoiDungId = null)
        {
            _loNongSanBusiness.UpdateStatus(id, trangThaiMoi, nguoiDungId);
            return Ok(new { message = $"Đã cập nhật trạng thái lô số {id} thành: {trangThaiMoi}!" });
        }

        [HttpPut("mark-expired")]
        public IActionResult MarkExpired()
        {
            int soLoBiKhoa = _loNongSanBusiness.MarkExpired();
            return Ok(new { message = $"Quét hoàn tất! Đã khóa {soLoBiKhoa} lô nông sản hết hạn." });
        }
    }
}
