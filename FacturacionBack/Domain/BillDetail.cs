using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBack.Domain
{
    public class BillDetail
    {
        public int Id { get; set; }
        public List <Product> IdProduct { get; set; }
        public int Amount { get; set; }
        public List <Bill> IdBill { get; set; }

        public override string ToString()
        {
            return Id + " - " + IdProduct+ " - " + Amount + " - " + IdBill;
        }
    }
}
