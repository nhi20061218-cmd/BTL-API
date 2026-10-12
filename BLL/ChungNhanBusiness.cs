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
    public class ChungNhanBusiness : IChungNhanBusiness
    {
        private readonly IChungNhanRepository _res;
        public ChungNhanBusiness(IChungNhanRepository res) => _res = res;

        public bool Create(ChungNhan model)
        {
            return _res.Create(model);
        }

        public IEnumerable<ChungNhan> GetByLo(int maLoNongSan)
        {
            return _res.GetByLo(maLoNongSan);
        }
    }
}
