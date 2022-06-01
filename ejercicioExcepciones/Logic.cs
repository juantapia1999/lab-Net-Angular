using ejercicioExcepciones.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioExcepciones
{
    public class Logic
    {
        public void NoImplementado()
        {
            throw new NotImplementedException();
        }

        public void DisparadorExcepcion()
        {
            CustomException.ThrowDividendoException();
        }

        public void ExcepcionPersonalizada()
        {
            throw new DividendoException("Se disparo una excepcion con intencion");
        }
    }
}
