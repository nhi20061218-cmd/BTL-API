using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INguoiDungRepository
    {
        bool Create(NguoiDung model);
        NguoiDung GetByUsername(string username);
    }
}
