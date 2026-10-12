using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL.Interfaces;

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamBusiness _sanPhamBusiness;

        public SanPhamController(ISanPhamBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] SanPham request)
        {
            int newId = _sanPhamBusiness.Create(request);
            return Ok(new { message = "Thêm sản phẩm thành công!", maSanPham = newId });
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] SanPham request)
        {
            _sanPhamBusiness.Update(request);
            return Ok(new { message = "Cập nhật sản phẩm thành công!" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _sanPhamBusiness.Delete(id);
            return Ok(new { message = "Xóa sản phẩm thành công!" });
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_sanPhamBusiness.GetAll());
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? tenSanPham = null, [FromQuery] string? loaiSanPham = null)
        {
            var result = _sanPhamBusiness.Search(page, pageSize, tenSanPham, loaiSanPham);
            return Ok(result);
        }
    }
}

