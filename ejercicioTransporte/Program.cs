using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Transporte> transporte = new List<Transporte>();
            /*List<Transporte> transporte = new List<Transporte> {
                new Taxi(5),
                new Omnibus(31),
                new Taxi(4),
                new Omnibus(32),
                new Taxi(2),
                new Taxi(5),
                new Omnibus(25),
                new Omnibus(45),
                new Omnibus(13),
            };*/
            int opcion = 0;
            int cantidad = 0;

            do
            {
                Console.WriteLine("\n********************************************");
                Console.WriteLine("Ingrese un número de Opción");
                Console.WriteLine("1. Cargar un Taxi");
                Console.WriteLine("2. Cargar un Omnibus");
                Console.WriteLine("3. Ver Listado de Taxis");
                Console.WriteLine("4. Ver Listado de Omnibus");
                Console.WriteLine("5. Ver Listado de todos los Transportes");
                Console.WriteLine("0. Salir");
                Console.Write("Respuesta: ");
                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("********************************************\n");

                switch (opcion)
                {
                    case 1:
                        {
                            var filtroTaxi = transporte.FindAll(t => t.TipoTransporte() == "taxi");
                            if (filtroTaxi.Count() >= 5)
                            {
                                Console.WriteLine("Ya cargo los  5 taxis");
                                break;
                            }

                            Console.WriteLine("Ingrese cantidad de Pasajeros para un Taxi");
                            string aux = Console.ReadLine();
                            if (int.TryParse(aux, out cantidad))
                            {
                                if (cantidad >= 0 && cantidad <= 5)
                                {
                                    transporte.Add(new Taxi(cantidad));
                                    Console.WriteLine("Se agrego un taxi");
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese una cantidad valida de Pasajeros");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ingrese una cantidad valida de Pasajeros");
                            }

                            break;
                        }
                    case 2:
                        {
                            var filtroOmnibus = transporte.FindAll(t => t.TipoTransporte() == "omnibus");
                            if (filtroOmnibus.Count() >= 5)
                            {
                                Console.WriteLine("Ya cargo los  5 omnibus");
                                break;
                            }
                            Console.WriteLine("Ingrese cantidad de Pasajeros para un Omnibus");
                            string aux = Console.ReadLine();
                            if (int.TryParse(aux, out cantidad))
                            {
                                if (cantidad >= 0 && cantidad <= 100)
                                {
                                    transporte.Add(new Omnibus(cantidad));
                                    Console.WriteLine("Se agrego un omnibus");
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese una cantidad valida de Pasajeros");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ingrese una cantidad valida de Pasajeros");
                            }

                            break;
                        }
                    case 3:
                        {
                            var filtroTaxi = transporte.FindAll(t => t.TipoTransporte() == "taxi");
                            if (filtroTaxi.Count() < 1)
                            {
                                Console.WriteLine("No hay taxis cargados");
                                break;
                            }
                            foreach (var item in transporte)
                            {
                                if (item.TipoTransporte() == "taxi")
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            var filtroOmnibus = transporte.FindAll(t => t.TipoTransporte() == "omnibus");
                            if (filtroOmnibus.Count() < 1)
                            {
                                Console.WriteLine("No hay omnibuses cargados");
                                break;
                            }
                            foreach (var item in transporte)
                            {
                                if (item.TipoTransporte() == "omnibus")
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            if (transporte.Count() < 1)
                            {
                                Console.WriteLine("No hay transportes cargados");
                                break;
                            }
                            foreach (var item in transporte)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Saliendo del Menú ........");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ingrese una opción valida del menú");
                            break;
                        }
                }
            } while (opcion != 0);
            Console.WriteLine("Fin de la ejecución");
            Console.ReadKey();
        }
    }
}
