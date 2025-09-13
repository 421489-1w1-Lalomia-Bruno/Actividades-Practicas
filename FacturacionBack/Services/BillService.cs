using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionBack.Domain;
using FacturacionBack.Data;
using FacturacionBack.Data.Interfaces;
using FacturacionBack.Data.Repositories;

namespace FacturacionBack.Services
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
