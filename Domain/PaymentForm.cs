using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Domain
{
    public class PaymentForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return Id + " - " + Name;
        }
    }
}
