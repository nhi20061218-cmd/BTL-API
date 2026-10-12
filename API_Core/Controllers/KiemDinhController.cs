using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiemDinhController : ControllerBase
    {
        private readonly IKiemDinhBusiness _kiemDinhBusiness;

        public KiemDinhController(IKiemDinhBusiness kiemDinhBusiness)
        {
            _kiemDinhBusiness = kiemDinhBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] KiemDinh request)
        {
            int maKiemDinh = _kiemDinhBusiness.Create(request);
            return Ok(new
            {
                message = request.KetQua == "Pass" ? "Kiểm định ĐẠT! Lô hàng đã thăng cấp thành Inspected." : "Kiểm định KHÔNG ĐẠT! Lô hàng đã bị khóa.",
                maKiemDinh = maKiemDinh
            });
        }

        [HttpGet("get-by-lo/{maLoNongSan}")]
        public IActionResult GetByLo(int maLoNongSan)
        {
            return Ok(_kiemDinhBusiness.GetByLo(maLoNongSan));
        }

        [HttpGet("get-data-to-sign/{maKiemDinh}")]
        public IActionResult GetDataToSign(int maKiemDinh)
        {
            return Ok(_kiemDinhBusiness.GetDataToSign(maKiemDinh));
        }

        [HttpPost("save-signature")]
        public IActionResult SaveSignature([FromBody] KiemDinhSignatureModel request)
        {
            _kiemDinhBusiness.SaveSignature(request);
            return Ok(new { message = "Biên bản đã được ký số và khóa vĩnh viễn!" });
        }

        [HttpGet("verify/{maKiemDinh}")]
        public IActionResult Verify(int maKiemDinh)
        {
            var result = _kiemDinhBusiness.Verify(maKiemDinh);
            return Ok(result);
        }
    }
}

