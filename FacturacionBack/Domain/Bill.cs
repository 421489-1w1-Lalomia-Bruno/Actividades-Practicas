using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBack.Domain
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdpaymentForm { get; set; }
        public string Client { get; set; }

        public override string ToString()
        {
            return Id + " - " + Date + " - " + IdpaymentForm;
        }

    }
}
