using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioTransporte
{
    class Taxi : Transporte
    {

        private static int contadorInstancia;
        public int Id { get; private set; }

        public Taxi(int cantidadPasajeros) : base(cantidadPasajeros)
        {
            this.Pasajeros = cantidadPasajeros;
            Id = ++contadorInstancia;
        }
        public override string Avanzar()
        {
            return $"El taxi avanza con {Pasajeros}";
        }

        public override string Detenerse()
        {
            return $"El taxi se detiene con {Pasajeros}";
        }

        public override string TipoTransporte()
        {
            return "taxi";
        }

        public override string ToString()
        {
            return $"Taxi {Id}: {Pasajeros} pasajeros";
        }
    }
}
