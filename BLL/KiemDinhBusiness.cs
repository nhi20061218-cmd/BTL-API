using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KiemDinhBusiness : IKiemDinhBusiness
    {
        private readonly IKiemDinhRepository _res;
        public KiemDinhBusiness(IKiemDinhRepository res) => _res = res;

        public int Create(KiemDinh model) => _res.Create(model);
        public IEnumerable<dynamic> GetByLo(int maLoNongSan) => _res.GetByLo(maLoNongSan);
        public dynamic GetDataToSign(int maKiemDinh) => _res.GetDataToSign(maKiemDinh);
        public dynamic Verify(int maKiemDinh) => _res.Verify(maKiemDinh);

        public bool SaveSignature(KiemDinhSignatureModel model)
        {
            // Chuyển chuỗi Base64 từ Frontend thành mảng byte để ném xuống SQL Server
            byte[] chuKySoBytes = Convert.FromBase64String(model.ChuKySoBase64);
            return _res.SaveSignature(model.MaKiemDinh, chuKySoBytes, model.KhoaCongKhai, model.DuongDanBienBan);
        }
    }
}
