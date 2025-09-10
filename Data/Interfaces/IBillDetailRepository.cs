using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Practica01_.Domain;

namespace Proyecto_Practica01_.Data.Interfaces
{
    public interface IBillDetailRepository
    {
        List<BillDetail> GetAll();
        BillDetail? GetById(int id);
        bool Save(BillDetail detail);
        bool Delete(int id);
    }
}
