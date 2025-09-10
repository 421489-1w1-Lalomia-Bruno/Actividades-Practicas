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
