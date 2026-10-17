using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INhatKyHeThongBusiness
    {
        public interface INhatKyBusiness
        {
            bool Create(NhatKy model);
            IEnumerable<NhatKy> Search(int pageIndex, int pageSize, string hanhDong, string maDoiTuong);
            IEnumerable<NhatKy> ThongKeQuet(string? maLoHang);
        }
    }
}
