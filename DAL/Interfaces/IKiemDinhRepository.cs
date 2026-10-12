using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IKiemDinhRepository
    {
        int Create(KiemDinh model);
        IEnumerable<dynamic> GetByLo(int maLoNongSan);
        dynamic GetDataToSign(int maKiemDinh);
        bool SaveSignature(int maKiemDinh, byte[] chuKySo, string khoaCongKhai, string? duongDan);
        dynamic Verify(int maKiemDinh);
    }
}
