using BLL;
using BLL.Interfaces;
using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using DAL;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
