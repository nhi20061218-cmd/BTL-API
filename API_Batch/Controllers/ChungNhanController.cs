using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Batch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChungNhanController : ControllerBase
    {
        private readonly IChungNhanBusiness _chungNhanBusiness;

        public ChungNhanController(IChungNhanBusiness chungNhanBusiness)
        {
            _chungNhanBusiness = chungNhanBusiness;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ChungNhan request)
        {
            _chungNhanBusiness.Create(request);
            return Ok(new { message = $"Đã cấp chứng nhận {request.LoaiChungNhan} cho lô nông sản số {request.MaLoNongSan}!" });
        }

        [HttpGet("get-by-lo/{maLoNongSan}")]
        public IActionResult GetByLo(int maLoNongSan)
        {
            var result = _chungNhanBusiness.GetByLo(maLoNongSan);
            return Ok(result);
        }
    }
}
