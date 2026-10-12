using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILoNongSanRepository
    {
        string Create(LoNongSan model, int nguoiDungId);
        IEnumerable<LoNongSan> Search(int pageIndex, int pageSize, string? trangThai, int? maTrangTrai);
        bool Update(LoNongSan model);
        bool Delete(int id);
        bool UpdateStatus(int maLoNongSan, string trangThaiMoi, int? nguoiDungId);
        int MarkExpired();
    }
}
