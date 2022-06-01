using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioExcepciones.Exceptions
{
    class CustomException
    {
        public static void ThrowDividendoException()
        {
            throw new DividendoException();
        }
    }
}
