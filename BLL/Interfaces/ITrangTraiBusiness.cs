using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITrangTraiBusiness
    {
        int Create(TrangTrai model);
        object Search(int pageIndex, int pageSize, string? tenTrangTrai, int? maChuTrangTrai);
        bool Update(TrangTrai model);
        bool Delete(int maTrangTrai);
    }
}
