using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionBack.Domain;

namespace FacturacionBack.Data.Interfaces
{
    public interface IBillRepository
    {
        List<Bill> GetAll();
        Bill GetById(int id);
        int Save(Bill bill);
        int Delete(int id);
    }
}
