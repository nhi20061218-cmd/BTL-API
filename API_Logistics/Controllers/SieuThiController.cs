using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Logistics.Controllers
{
    [Authorize(Roles = "Retailer,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SieuThiController : ControllerBase
    {
        private readonly ISieuThiBusiness _sieuThiBusiness;

        public SieuThiController(ISieuThiBusiness sieuThiBusiness)
        {
            _sieuThiBusiness = sieuThiBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] SieuThi request)
        {
            int newId = _sieuThiBusiness.Create(request);
            return Ok(new { message = "Thêm siêu thị thành công!", maSieuThi = newId });
        }

        [HttpGet("get-by-user/{maNguoiDung}")]
        public IActionResult GetByUser(int maNguoiDung)
        {
            var result = _sieuThiBusiness.GetByUser(maNguoiDung);
            if (result == null || !result.Any())
                return NotFound(new { message = "Không tìm thấy hồ sơ siêu thị nào cho người dùng này." });

            return Ok(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_sieuThiBusiness.GetAll());
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _sieuThiBusiness.Delete(id);
            return Ok(new { message = "Xóa siêu thị thành công!" });
        }
    }
}

