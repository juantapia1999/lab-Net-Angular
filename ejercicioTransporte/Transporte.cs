using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioTransporte
{
    public abstract class Transporte
    {
        private int pasajeros;
        public int Pasajeros
        {
            get
            {
                return pasajeros;
            }
            set
            {
                pasajeros = value;
            }
        }

        public Transporte(int cantidadPasajeros)
        {
            this.Pasajeros = cantidadPasajeros;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();

        public abstract string TipoTransporte();
    }
}
