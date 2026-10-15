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

// 1. L?y chìa khóa bí m?t t? file appsettings.json
var secretKey = builder.Configuration["AppSettings:Secret"];
var key = Encoding.UTF8.GetBytes(secretKey);

// 2. L?p ??t c?u hình máy quét th? (Authentication)
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
        ValidateIssuerSigningKey = true, // Ph?i ki?m tra ch? ký
        IssuerSigningKey = new SymmetricSecurityKey(key), // Dùng chìa khóa này ?? quét
        ValidateIssuer = false,
        ValidateAudience = false,
        RoleClaimType = System.Security.Claims.ClaimTypes.Role // Khai báo ch? ??c Quy?n (Role)
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddTransient<INhaPhanPhoiRepository, NhaPhanPhoiRepository>();
builder.Services.AddTransient<INhaPhanPhoiBusiness, NhaPhanPhoiBusiness>();
builder.Services.AddTransient<ISieuThiRepository, SieuThiRepository>();
builder.Services.AddTransient<ISieuThiBusiness, SieuThiBusiness>();
builder.Services.AddTransient<IKhoHangRepository, KhoHangRepository>();
builder.Services.AddTransient<IKhoHangBusiness, KhoHangBusiness>();
builder.Services.AddTransient<IVanChuyenRepository, VanChuyenRepository>();
builder.Services.AddTransient<IVanChuyenBusiness, VanChuyenBusiness>();
builder.Services.AddTransient<ITonKhoRepository, TonKhoRepository>();
builder.Services.AddTransient<ITonKhoBusiness, TonKhoBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- B?T ??U B?T B?O M?T ---
app.UseAuthentication(); // B?t máy quét th? (Ki?m tra Token h?p l?)
app.UseAuthorization();  // B?t b?o v? (Ki?m tra xem Role có ???c phép vào hay không)
app.MapControllers();

app.Run();
