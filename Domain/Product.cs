using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Domain
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return Code + " - " + Name + " - $" + Price;
        }

    }
}
