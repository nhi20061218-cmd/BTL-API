using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITrangTraiRepository
    {
        int Create(TrangTrai model);
        IEnumerable<TrangTrai> Search(int pageIndex, int pageSize, string? tenTrangTrai, int? maChuTrangTrai);
        bool Update(TrangTrai model);
        bool Delete(int maTrangTrai);
    }
}
