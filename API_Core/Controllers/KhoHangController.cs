using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoHangController : ControllerBase
    {
        private readonly IKhoHangBusiness _khoHangBusiness;

        public KhoHangController(IKhoHangBusiness khoHangBusiness)
        {
            _khoHangBusiness = khoHangBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] KhoHang request)
        {
            int newId = _khoHangBusiness.Create(request);
            return Ok(new { message = "Thêm kho hàng thành công!", maKhoHang = newId });
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] KhoHang request)
        {
            _khoHangBusiness.Update(request);
            return Ok(new { message = "Cập nhật kho hàng thành công!" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _khoHangBusiness.Delete(id);
            return Ok(new { message = "Xóa kho hàng thành công!" });
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _khoHangBusiness.GetById(id);
            if (result == null) return NotFound(new { message = "Không tìm thấy kho hàng." });
            return Ok(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll([FromQuery] int? maNhaPhanPhoi = null)
        {
            return Ok(_khoHangBusiness.GetAll(maNhaPhanPhoi));
        }
    }
}
