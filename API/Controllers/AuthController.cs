using Asp.Versioning;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly INguoiDungBusiness _nguoiDungBusiness;

        public AuthController(INguoiDungBusiness nguoiDungBusiness)
        {
            _nguoiDungBusiness = nguoiDungBusiness;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestModel request)
        {
            _nguoiDungBusiness.Register(request);
            return Ok(new { message = "Đăng ký thành công!" });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            var user = _nguoiDungBusiness.Authenticate(request);
            if (user == null) return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu." });

            return Ok(new
            {
                maNguoiDung = user.MaNguoiDung,
                hoTen = user.HoTen,
                vaiTro = user.VaiTro, // Sẽ hiển thị chữ Admin, Farmer... nhờ câu JOIN
                token = user.Token
            });
        }
    }
}
