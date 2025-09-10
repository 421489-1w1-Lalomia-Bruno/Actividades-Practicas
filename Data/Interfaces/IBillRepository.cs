using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Practica01_.Domain;

namespace Proyecto_Practica01_.Data.Interfaces
{
    public interface IBillRepository
    {
        List<Bill> GetAll();
        Bill GetById(int id);
        int Save(Bill bill);
        int Delete(int id);
    }
}
