using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Logistics.Controllers
{
    [Authorize(Roles = "Distributor,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TonKhoController : ControllerBase
    {
        private readonly ITonKhoBusiness _tonKhoBusiness;

        public TonKhoController(ITonKhoBusiness tonKhoBusiness)
        {
            _tonKhoBusiness = tonKhoBusiness;
        }

        // Lấy danh sách tồn kho (Có thể truyền ID kho để lọc, hoặc bỏ trống để xem toàn bộ)
        [HttpGet("get-all")]
        public IActionResult GetByKho([FromQuery] int? maKhoHang = null)
        {
            return Ok(_tonKhoBusiness.GetByKho(maKhoHang));
        }

        // API Cảnh báo lô hàng sắp hết hạn (Mặc định báo trước 7 ngày nếu không truyền tham số)
        [HttpGet("canh-bao-het-han")]
        public IActionResult GetHetHan([FromQuery] int soNgay = 7)
        {
            return Ok(_tonKhoBusiness.GetHetHan(soNgay));
        }
    }
}

