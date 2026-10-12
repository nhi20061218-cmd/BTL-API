using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INhaPhanPhoiRepository
    {
        int Create(NhaPhanPhoi model);
        IEnumerable<NhaPhanPhoi> GetByUser(int maNguoiDung);
        IEnumerable<NhaPhanPhoi> GetAll();
        bool Delete(int id); // <--- Dòng mới thêm
    }
}
