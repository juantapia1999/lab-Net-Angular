using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioTransporte
{
    class Omnibus : Transporte
    {
        private static int contadorInstancia;
        public int Id { get; private set; }
        public Omnibus(int cantidadPasajeros) : base(cantidadPasajeros)
        {
            this.Pasajeros = cantidadPasajeros;
            Id = ++contadorInstancia;
        }

        public override string Avanzar()
        {
            return $"El Omnibus avanza con {Pasajeros} pasajeros";
        }

        public override string Detenerse()
        {
            return $"El Omnibus se detiene con {Pasajeros} pasajeros";
        }

        public override string TipoTransporte()
        {
            return "omnibus";
        }

        public override string ToString()
        {
            return $"Omnibus {Id}: {Pasajeros} pasajeros";
        }
    }
}
