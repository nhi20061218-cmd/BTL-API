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
            private readonly IConfiguration _config;

            public NguoiDungBusiness(INguoiDungRepository res, IConfiguration config)
            {
                _res = res;
                _config = config;
            }

            public bool Register(RegisterRequestModel request)
            {
                // 1. Kiểm tra chống trùng tên đăng nhập
                var checkUser = _res.GetByUsername(request.TenDangNhap);
                if (checkUser != null)
                    throw new Exception("Tên đăng nhập đã tồn tại trong hệ thống!");

                // 2. Băm mật khẩu bằng BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.MatKhau);

                // 3. Nạp vào Model và lưu xuống DB
                var newUser = new NguoiDung
                {
                    TenDangNhap = request.TenDangNhap,
                    MatKhauHash = hashedPassword,
                    HoTen = request.HoTen,
                    Email = request.Email,
                    SoDienThoai = request.SoDienThoai,
                    MaVaiTro = request.MaVaiTro
                };

                return _res.Create(newUser);
            }

            public NguoiDung Authenticate(LoginRequestModel request)
            {
                // 1. Tìm user trong DB
                var user = _res.GetByUsername(request.TenDangNhap);

                // Nếu không thấy user hoặc tài khoản bị khóa (HoatDong = false)
                if (user == null || !user.HoatDong)
                    return null;

                // 2. Kiểm tra mật khẩu
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.MatKhau, user.MatKhauHash);
                if (!isPasswordValid) return null;

                // 3. Cấp Token và giấu mật khẩu trước khi trả về
                user.Token = GenerateJwtToken(user);
                user.MatKhauHash = "";

                return user;
            }

            private string GenerateJwtToken(NguoiDung user)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["AppSettings:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, user.MaNguoiDung.ToString()),
                    new Claim(ClaimTypes.Name, user.TenDangNhap),
                    new Claim(ClaimTypes.Role, user.VaiTro ?? "Unknown")
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            }

        // ==========================================
        // CÁC HÀM DÀNH CHO API_ADMIN
        // ==========================================
        public NguoiDung GetById(int maNguoiDung) => _res.GetById(maNguoiDung);

        public IEnumerable<NguoiDung> Search(int pageIndex, int pageSize, string? hoTen, string? tenDangNhap, int? maVaiTro)
        {
            return _res.Search(pageIndex, pageSize, hoTen, tenDangNhap, maVaiTro);
        }

        public bool Update(NguoiDung model)
        {
            // 1. Lấy thông tin CŨ đang nằm dưới database lên
            var existingUser = _res.GetById(model.MaNguoiDung);
            if (existingUser == null)
                throw new Exception("Không tìm thấy tài khoản cần sửa!");

            // 2. Trộn dữ liệu: Kiểm tra xem Frontend có truyền dữ liệu lên không
            // Nếu dữ liệu truyền lên khác rỗng (!string.IsNullOrEmpty) -> Lấy dữ liệu mới
            // Nếu rỗng (người dùng không truyền) -> Giữ nguyên dữ liệu cũ của existingUser
            existingUser.HoTen = !string.IsNullOrEmpty(model.HoTen) ? model.HoTen : existingUser.HoTen;
            existingUser.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : existingUser.Email;
            existingUser.SoDienThoai = !string.IsNullOrEmpty(model.SoDienThoai) ? model.SoDienThoai : existingUser.SoDienThoai;

            // 3. Đưa object đã được đắp dữ liệu hoàn chỉnh xuống DAL (chạy SP update)
            return _res.Update(existingUser);
        }

        public bool SetRole(int maNguoiDung, int maVaiTro) => _res.SetRole(maNguoiDung, maVaiTro);

        public bool SetActive(int maNguoiDung, bool hoatDong) => _res.SetActive(maNguoiDung, hoatDong);

        public bool SetPassword(int maNguoiDung, string matKhauMoi)
        {
            // Băm nát mật khẩu mới thành mã hóa trước khi đưa xuống DB
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhauMoi);
            return _res.SetPassword(maNguoiDung, hashedPassword);
        }

        public bool Delete(int maNguoiDung)
        {
           
            return _res.Delete(maNguoiDung);
        }
    }
    }
