using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioExcepciones
{
    public class OperacionAritmetica
    {
        public static double Suma(double a, double b)
        {
            return a + b;
        }

        public static double Resta(double a, double b)
        {
            return a - b;
        }

        public static double Multiplicacion(double a, double b)
        {
            return a * b;
        }

        public static double Division(double a, double b)
        {
            try
            {
                return a / b;
            }
            catch(DivideByZeroException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
