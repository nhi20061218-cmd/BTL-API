using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguoiDungBusiness : INguoiDungBusiness
    {
        private readonly INguoiDungRepository _res;
        private readonly string _secretKey;

        public NguoiDungBusiness(INguoiDungRepository res, IConfiguration configuration)
        {
            _res = res;
            _secretKey = configuration["AppSettings:Secret"]
                ?? throw new Exception("Thiếu Secret Key");
        }

        // HÀM HỖ TRỢ: Chuyển chuỗi thường thành chuỗi băm MD5
        private string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển mảng byte thành chuỗi Hexa (ví dụ: e10adc3949ba59abbe56e057f20f883e)
                return Convert.ToHexString(hashBytes).ToLower();
            }
        }

        public bool Register(RegisterRequestModel request)
        {
            var existingUser = _res.GetByUsername(request.TenDangNhap);
            if (existingUser != null)
                throw new ArgumentException("Tên đăng nhập đã tồn tại.");

            var model = new NguoiDung
            {
                TenDangNhap = request.TenDangNhap,
                // THAY THẾ BCRYPT BẰNG MD5 TẠI ĐÂY
                MatKhauHash = GetMD5Hash(request.MatKhau),
                HoTen = request.HoTen,
                Email = request.Email,
                SoDienThoai = request.SoDienThoai,
                MaVaiTro = request.MaVaiTro
            };

            return _res.Create(model);
        }

        public NguoiDung Authenticate(LoginRequestModel request)
        {
            var user = _res.GetByUsername(request.TenDangNhap);

            // Băm mật khẩu người dùng nhập vào bằng MD5 và SO SÁNH với chuỗi MD5 trong Database
            if (user == null || GetMD5Hash(request.MatKhau) != user.MatKhauHash)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.MaNguoiDung.ToString()),
                    new Claim(ClaimTypes.Name, user.HoTen),
                    //new Claim(ClaimTypes.Role, user.VaiTro)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.MatKhauHash = ""; // Xóa password hash khỏi RAM trước khi gửi về API

            return user;
        }
    }
}
