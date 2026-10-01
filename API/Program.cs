using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IO.Compression;
using System.Text;
using System.Threading.RateLimiting;

// 1. CẤU HÌNH GHI LOG (SERILOG)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/app_log_.txt", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

try
{
    Log.Information("Đang khởi động Web API Quản lý Nông Sản...");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("Logs/app_log_.txt", rollingInterval: RollingInterval.Day));

    // 2. CẤU HÌNH CORS (Bảo mật tên miền)
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });

    // 3. ĐĂNG KÝ DEPENDENCY INJECTION (DI)
    builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
    builder.Services.AddTransient<INguoiDungBusiness, NguoiDungBusiness>();
    builder.Services.AddTransient<INguoiDungRepository, NguoiDungRepository>();
    // Lưu ý: Sau này làm bảng nào, bạn Un-comment hoặc viết thêm đăng ký vào đây
    // builder.Services.AddTransient<IUserRepository, UserRepository>();
    // builder.Services.AddTransient<IUserBusiness, UserBusiness>();

    // 4. CACHE & COMPRESSION (Tối ưu hiệu năng)
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
        options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>();
    });

    // 5. CHỐNG SPAM API (Rate Limiting)
    builder.Services.AddRateLimiter(options =>
    {
        options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        options.AddPolicy("FixedWindowPolicy", httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
                factory: _ => new FixedWindowRateLimiterOptions { PermitLimit = 100, Window = TimeSpan.FromMinutes(1) }));
    });

    // 6. BẢO MẬT JWT (Đăng nhập)
    var secretKey = builder.Configuration["AppSettings:Secret"] ?? "CHUA_CO_SECRET_KEY";
    var key = Encoding.UTF8.GetBytes(secretKey);
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

    // 7. API VERSIONING (Quản lý phiên bản API v1, v2)
    // 7. API VERSIONING (Quản lý phiên bản API v1, v2)
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    }).AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // ==========================================
    // CẤU HÌNH PIPELINE (MIDDLEWARE)
    // ==========================================

    // Bắt lỗi toàn cục của thầy giáo

    app.UseResponseCompression();
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseCors("AllowAll");
    app.UseRateLimiter();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers().RequireRateLimiting("FixedWindowPolicy");

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Ứng dụng bị dừng bất ngờ do lỗi!");
}
finally
{
    Log.CloseAndFlush();
}
