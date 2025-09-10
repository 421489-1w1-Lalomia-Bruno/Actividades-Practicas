using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Domain
{
    public class SpParam
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public SpParam() { }

        public SpParam(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
