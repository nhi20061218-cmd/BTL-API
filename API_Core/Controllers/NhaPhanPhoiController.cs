using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;
namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaPhanPhoiController : ControllerBase
    {
        private readonly INhaPhanPhoiBusiness _nhaPhanPhoiBusiness;

        public NhaPhanPhoiController(INhaPhanPhoiBusiness nhaPhanPhoiBusiness)
        {
            _nhaPhanPhoiBusiness = nhaPhanPhoiBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] NhaPhanPhoi request)
        {
            int newId = _nhaPhanPhoiBusiness.Create(request);
            return Ok(new { message = "Thêm nhà phân phối thành công!", maNhaPhanPhoi = newId });
        }
        [HttpGet("get-by-user/{maNguoiDung}")]
        public IActionResult GetByUser(int maNguoiDung)
        {
            var result = _nhaPhanPhoiBusiness.GetByUser(maNguoiDung);
            if (result == null || !result.Any())
                return NotFound(new { message = "Không tìm thấy hồ sơ nhà phân phối nào cho người dùng này." });

            return Ok(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_nhaPhanPhoiBusiness.GetAll());
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _nhaPhanPhoiBusiness.Delete(id);
            return Ok(new { message = "Xóa nhà phân phối thành công!" });
        }
    }
}
