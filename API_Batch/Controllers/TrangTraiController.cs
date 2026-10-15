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
    public class TrangTraiController : ControllerBase
    {
        private readonly ITrangTraiBusiness _trangTraiBusiness;

        public TrangTraiController(ITrangTraiBusiness trangTraiBusiness)
        {
            _trangTraiBusiness = trangTraiBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] TrangTrai request)
        {
            var id = _trangTraiBusiness.Create(request);
            return Ok(new { message = "Tạo trang trại thành công!", maTrangTrai = id });
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? ten = null, [FromQuery] int? maChu = null)
        {
            var result = _trangTraiBusiness.Search(page, pageSize, ten, maChu);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrangTrai request)
        {
            _trangTraiBusiness.Update(request);
            return Ok(new { message = "Cập nhật thông tin trang trại thành công!" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _trangTraiBusiness.Delete(id);
            return Ok(new { message = "Xóa trang trại thành công!" });
        }
    }
}
