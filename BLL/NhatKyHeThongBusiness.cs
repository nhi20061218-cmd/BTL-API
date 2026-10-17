using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Interfaces.INhatKyHeThongBusiness;

namespace BLL
{
    public class NhatKyBusiness : INhatKyBusiness
    {
    
            private readonly INhatKyRepository _res;

            public NhatKyBusiness(INhatKyRepository res)
            {
                _res = res;
            }

            public bool Create(NhatKy model)
            {
                return _res.Create(model);
            }

            public IEnumerable<NhatKy> Search(int pageIndex, int pageSize, string hanhDong, string maDoiTuong)
            {
                return _res.Search(pageIndex, pageSize, hanhDong, maDoiTuong);
            }
        public IEnumerable<NhatKy> ThongKeQuet(string? maLoHang)
        {
            return _res.ThongKeQuet(maLoHang);
        }
    }
    }


