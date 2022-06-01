using ejercicioExcepciones.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioExcepciones
{
    class Numeros
    {
        public double NumA
        {
            get { return NumA; }
            set { NumA = value; }
        }
        public double NumB
        {
            get { return NumB; }
            set
            { NumB = value; }
        }

        public string Operador { get; set; }
        public double Resultado { get; set; }

        public Numeros() { }

        //se comento para forzar el error de los seters
        //public Numeros(double numA, double numb)
        //{
        //    this.NumA = numA;
        //    this.NumB = numb;
        //}

        public override string ToString()
        {
            return $"{NumA} {Operador} {NumB} = {Resultado}";
        }
    }
}
