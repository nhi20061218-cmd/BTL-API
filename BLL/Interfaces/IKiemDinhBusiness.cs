using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IKiemDinhBusiness
    {
        int Create(KiemDinh model);
        IEnumerable<dynamic> GetByLo(int maLoNongSan);
        dynamic GetDataToSign(int maKiemDinh);
        bool SaveSignature(KiemDinhSignatureModel model);
        dynamic Verify(int maKiemDinh);
    }
}
