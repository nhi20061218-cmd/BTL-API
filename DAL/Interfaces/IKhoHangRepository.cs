using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    
        public interface IKhoHangRepository
        {
            int Create(KhoHang model);
            bool Update(KhoHang model);
            bool Delete(int id);
            KhoHang GetById(int id);
            IEnumerable<KhoHang> GetAll(int? maNhaPhanPhoi);
        }
    
}