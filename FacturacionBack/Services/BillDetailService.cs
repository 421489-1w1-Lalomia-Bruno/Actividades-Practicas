using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionBack.Domain;
using FacturacionBack.Data.Interfaces;
using FacturacionBack.Data.Repositories;

namespace FacturacionBack.Services
{
    public class BillDetailService
    {
        private IBillDetailRepository _repository;

        public BillDetailService()
        {
            _repository = new BillDetailRepository();
        }

        public List<BillDetail> GetAllBillDetails()
        {
            return _repository.GetAll();
        }
    }
}
