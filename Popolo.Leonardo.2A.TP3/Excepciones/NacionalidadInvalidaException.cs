using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_abstractas
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : base()
        {
 
        }

        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {
 
        }
    }
}
