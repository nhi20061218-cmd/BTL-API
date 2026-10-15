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

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddTransient<INguoiDungRepository, NguoiDungRepository>();
builder.Services.AddTransient<INguoiDungBusiness, NguoiDungBusiness>();

// Khi nào viết code cho bảng Nhật Ký thì bạn un-comment 2 dòng dưới:
// builder.Services.AddTransient<INhatKyRepository, NhatKyRepository>();
// builder.Services.AddTransient<INhatKyBusiness, NhatKyBusiness>();

// Đọc chìa khóa bí mật
var secretKey = builder.Configuration["AppSettings:Secret"];
var key = Encoding.UTF8.GetBytes(secretKey);

// Đăng ký dịch vụ xác thực JWT
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
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // BỔ SUNG DÒNG NÀY ĐỂ KÍCH HOẠT QUÉT TOKEN
app.UseAuthorization();

app.MapControllers();

app.Run();
