using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioExcepciones.Exceptions
{
    public class DividendoException : Exception
    {
        public DividendoException() : base("No se puede dividir por cero") { }

        public DividendoException(string message) : base(message) { }

    }
}
