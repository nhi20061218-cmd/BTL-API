using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Lấy chìa khóa bí mật từ file appsettings.json
var secretKey = builder.Configuration["AppSettings:Secret"];
var key = Encoding.UTF8.GetBytes(secretKey);

// 2. Lắp đặt cấu hình máy quét thẻ (Authentication)
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Phải kiểm tra chữ ký
        IssuerSigningKey = new SymmetricSecurityKey(key), // Dùng chìa khóa này để quét
        ValidateIssuer = false,
        ValidateAudience = false,
        RoleClaimType = System.Security.Claims.ClaimTypes.Role // Khai báo chỗ đọc Quyền (Role)
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Đăng ký dùng chung ống nước Database
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddTransient<ITrangTraiRepository, TrangTraiRepository>();
builder.Services.AddTransient<ITrangTraiBusiness, TrangTraiBusiness>();
builder.Services.AddTransient<ILoNongSanRepository, LoNongSanRepository>();
builder.Services.AddTransient<ILoNongSanBusiness, LoNongSanBusiness>();
builder.Services.AddTransient<IChungNhanRepository, ChungNhanRepository>();
builder.Services.AddTransient<IChungNhanBusiness, ChungNhanBusiness>();
builder.Services.AddTransient<IKiemDinhRepository, KiemDinhRepository>();
builder.Services.AddTransient<IKiemDinhBusiness, KiemDinhBusiness>();
builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- BẮT ĐẦU BẬT BẢO MẬT ---
app.UseAuthentication(); // Bật máy quét thẻ (Kiểm tra Token hợp lệ)
app.UseAuthorization();  // Bật bảo vệ (Kiểm tra xem Role có được phép vào hay không)
// ---------------------------
app.MapControllers();

app.Run();
