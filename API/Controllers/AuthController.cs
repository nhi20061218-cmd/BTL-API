using Asp.Versioning;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Auth.Controllers
{
    // [AllowAnonymous] ở mức Controller để cho phép khách chưa đăng nhập vẫn gọi được
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly INguoiDungBusiness _nguoiDungBusiness;

        public AuthController(INguoiDungBusiness nguoiDungBusiness)
        {
            _nguoiDungBusiness = nguoiDungBusiness;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestModel request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenDangNhap) || string.IsNullOrEmpty(request.MatKhau))
                {
                    return BadRequest(new { message = "Tên đăng nhập và Mật khẩu không được để trống!" });
                }

                bool isSuccess = _nguoiDungBusiness.Register(request);

                if (isSuccess) return Ok(new { message = "Đăng ký tài khoản thành công!" });

                return BadRequest(new { message = "Đăng ký thất bại do lỗi hệ thống." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenDangNhap) || string.IsNullOrEmpty(request.MatKhau))
                {
                    return BadRequest(new { message = "Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!" });
                }

                var user = _nguoiDungBusiness.Authenticate(request);

                if (user == null)
                {
                    return Unauthorized(new { message = "Sai tài khoản, mật khẩu hoặc tài khoản đã bị khóa." });
                }

                return Ok(new
                {
                    maNguoiDung = user.MaNguoiDung,
                    tenDangNhap = user.TenDangNhap,
                    hoTen = user.HoTen,
                    vaiTro = user.VaiTro,
                    token = user.Token
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }
    }
}