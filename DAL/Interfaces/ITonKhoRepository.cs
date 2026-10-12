using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITonKhoRepository
    {
        IEnumerable<TonKho> GetByKho(int? maKhoHang);
        IEnumerable<TonKho> GetHetHan(int soNgay);
    }
}
