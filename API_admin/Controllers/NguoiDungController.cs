using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_admin.Controllers
{
    // Ổ KHÓA CHÍNH: Bắt buộc phải có Token hợp lệ VÀ Role là "Admin"
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungBusiness _nguoiDungBusiness;

        public NguoiDungController(INguoiDungBusiness nguoiDungBusiness)
        {
            _nguoiDungBusiness = nguoiDungBusiness;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string? hoTen = null, [FromQuery] string? tenDangNhap = null, [FromQuery] int? maVaiTro = null)
        {
            var result = _nguoiDungBusiness.Search(pageIndex, pageSize, hoTen, tenDangNhap, maVaiTro);
            return Ok(result);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _nguoiDungBusiness.GetById(id);
            if (user == null) return NotFound(new { message = "Không tìm thấy người dùng." });
            return Ok(user);
        }

        [HttpPatch("update")]
        public IActionResult Update([FromBody] NguoiDung model)
        {
            try
            {
                _nguoiDungBusiness.Update(model);
                return Ok(new { message = "Cập nhật thông tin thành công!" });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("set-role/{id}")]
        public IActionResult SetRole(int id, [FromBody] int maVaiTro)
        {
            try
            {
                _nguoiDungBusiness.SetRole(id, maVaiTro);
                return Ok(new { message = "Phân quyền thành công!" });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("set-active/{id}")]
        public IActionResult SetActive(int id, [FromBody] bool hoatDong)
        {
            _nguoiDungBusiness.SetActive(id, hoatDong);
            return Ok(new { message = hoatDong ? "Đã mở khóa tài khoản!" : "Đã khóa tài khoản!" });
        }

        [HttpPatch("set-password/{id}")]
        public IActionResult SetPassword(int id, [FromBody] string matKhauMoi)
        {
            if (string.IsNullOrEmpty(matKhauMoi)) return BadRequest(new { message = "Mật khẩu không được để trống." });

            _nguoiDungBusiness.SetPassword(id, matKhauMoi);
            return Ok(new { message = "Đổi mật khẩu thành công!" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _nguoiDungBusiness.Delete(id);
                return Ok(new { message = "Đã xóa tài khoản vĩnh viễn khỏi hệ thống!" });
            }
            catch (System.Exception ex)
            {
                // Bắt lỗi khóa ngoại nếu tài khoản đã dính líu đến dữ liệu khác
                return BadRequest(new { message = "Không thể xóa: Tài khoản này đã phát sinh dữ liệu trong hệ thống. Lỗi chi tiết: " + ex.Message });
            }
        }
    }
}

