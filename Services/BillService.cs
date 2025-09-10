using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Practica01_.Domain;
using Proyecto_Practica01_.Data;
using Proyecto_Practica01_.Data.Interfaces;
using Proyecto_Practica01_.Data.Repositories;

namespace Proyecto_Practica01_.Services
{
    public class BillService
    {
        private IBillRepository _repository;

        public BillService()
        {
            _repository = new BillRepository();
        }

        public List<Bill> GetAllBills()
        {
            return _repository.GetAll();
        }

        public Bill GetBill(int id)
        {
            return _repository.GetById(id);
        }
        public int SaveBill(Bill b)
        {
            return _repository.Save(b);
        }
        public int DeleteBill(int id)
        {
            return _repository.Delete(id);
        }
    }
}
