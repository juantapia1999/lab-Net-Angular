using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Logic;

namespace Tp5.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomersLogic customersLogic = new CustomersLogic();
            //foreach (var x in customersLogic.GetAllJoinWithOrdersByRegionAndDate())
            //{
            //    Console.WriteLine($"{x.CustomerID} {x.ContactName} {x.ShipName} {x.Region} {x.ShipRegion} {x.OrderDate} {x.OrderID}");                                                    
            //}
            int opcion = -1;
            string respuesta = "";

            do
            {
                Console.WriteLine("\n*******************************************************************************");
                Console.WriteLine("Ingrese un número de Opción");
                Console.WriteLine("1. Ver un Customer");
                Console.WriteLine("2. Ver todos los Products sin stock");
                Console.WriteLine("3. Ver Products con stock y precio unitario mayor a 3");
                Console.WriteLine("4. Ver todos los Customers de la Region WA");
                Console.WriteLine("5. Ver el primer Product segun Id");
                Console.WriteLine("6. Ver todos los nombres de los Customers en Mayuscula y minuscula");
                Console.WriteLine("7. Ver todos los Customers y sus Orders de la Region WA y fecha mayor a 1/1/97");
                Console.Write("Respuesta: ");
                respuesta = Console.ReadLine();
                if (!int.TryParse(respuesta, out opcion))
                {
                    opcion = -1;
                }

                Console.WriteLine("*******************************************************************************\n");
                switch (opcion)
                {
                    case 1:
                        {
                            VerCustomer();
                            break;
                        }
                    case 2:
                        {
                            VerProductosSinStock();
                            break;
                        }
                    case 3:
                        {
                            VerProductoConStockYPrecio();
                            break;
                        }
                    case 4:
                        {
                            VerCustomersSegunRegionWA();
                            break;
                        }
                    case 5:
                        {
                            VerPrimerProductSegunId();
                            break;
                        }
                    case 6:
                        {
                            VerNombresCustomerMayusculaMinuscula();
                            break;
                        }
                    case 7:
                        {
                            VerUnionCustomersOrders();
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
            Console.WriteLine("(Presione cualquier tecla para finalizar)");
            Console.ReadKey();
        }
        public static void VerCustomer()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            string idBuscado = "";

            Console.Write("Ingrese el ID: ");
            idBuscado = Console.ReadLine();

            try
            {
                var buscado = customersLogic.GetById(idBuscado);
                if (buscado != null)
                {
                    Console.WriteLine($"Id: {buscado.CustomerID} - Nombre de Compañia: {buscado.CompanyName} - Nombre de Contacto: {buscado.ContactName} - Region: {buscado.Region}");
                }
                else
                {
                    Console.WriteLine("Ingrese un Id valido");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un problema con su busqueda");
                throw;
            }

        }

        public static void VerProductosSinStock()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            try
            {
                foreach (var x in productsLogic.GetAllWithoutStock())
                {
                    Console.WriteLine($"Id: {x.ProductID} - Nombre: {x.ProductName} - Stock: {x.UnitsInStock}");
                }
                Console.WriteLine("Operacion realizada");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error con la consulta");
                throw;
            }
        }
        public static void VerProductoConStockYPrecio()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            try
            {
                foreach (var x in productsLogic.GetAllFilteredByUnitPrice())
                {
                    Console.WriteLine($"Id: {x.ProductID} - Nombre: {x.ProductName} - Stock: {x.UnitsInStock} - Precio Unitario: {x.UnitPrice}");
                }
                Console.WriteLine("Operacion realizada");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error con la consulta");
                throw;
            }
        }
        public static void VerCustomersSegunRegionWA()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            try
            {
                foreach (var x in customersLogic.GetAllFilteredByRegion())
                {
                    Console.WriteLine($"Id: {x.CustomerID} - Nombre de Compañia: {x.CompanyName} - Nombre de Contacto: {x.ContactName} - Region: {x.Region}");
                }
                Console.WriteLine("Operacion realizada");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error con la consulta");
            }
        }
        public static void VerPrimerProductSegunId()
        {
            string respuesta = "";
            int idBuscado = 0;

            ProductsLogic productsLogic = new ProductsLogic();

            Console.Write("Ingrese el ID: ");
            respuesta = Console.ReadLine();
            if (int.TryParse(respuesta, out idBuscado))
            {
                try
                {
                    var buscado = productsLogic.GetFirstById(idBuscado);
                    if (buscado != null)
                    {
                        Console.WriteLine($"Id: {buscado.ProductID} - Nombre: {buscado.ProductName} - Stock: {buscado.UnitsInStock} - Precio Unitario: {buscado.UnitPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un Id valido");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ocurrio un error con la consulta");
                }
            }
            else
            {
                Console.WriteLine("Ingrese un Id valido");
            }
        }

        public static void VerNombresCustomerMayusculaMinuscula()
        {
            try
            {
                CustomersLogic customersLogic = new CustomersLogic();
                Console.WriteLine("\n********** Listado de nombres en Mayuscula **********");
                foreach (var x in customersLogic.GetAllName(true))
                {
                    Console.WriteLine($"Nombre: {x}");
                }
                Console.WriteLine("\n********** Listado de nombres en Minuscula **********");
                foreach (var x in customersLogic.GetAllName(false))
                {
                    Console.WriteLine($"Nombre: {x}");
                }
                Console.WriteLine("Operacion realizada");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error con la consulta");
            }
        }

        public static void VerUnionCustomersOrders()
        {
            CustomersLogic customersLogic = new CustomersLogic();
            try
            {
                foreach (var x in customersLogic.GetAllJoinWithOrdersByRegionAndDate())
                {
                    Console.WriteLine($"ID Customer: {x.CustomerID} - Contact Name: {x.ContactName} - Shipper Name: {x.ShipName} - Customer Region: {x.Region} - Shipper Region: {x.ShipRegion} - Order Date: {x.OrderDate} - Order Id:{x.OrderID}");

                }
                Console.WriteLine("Operacion realizada");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error con la consulta");
            }


            try
            {
                foreach (var x in customersLogic.GetAllCountAndJoinWithOrdersByRegionAndDate())
                {
                    Console.WriteLine($"ID Customer: {x.Customers1.CustomerID} - Contact Name: {x.Customers1.ContactName} - Customer Region: {x.Customers1.Region} - Count: {x.CountOrder}");
                    foreach (var y in x.Orders1)
                    {
                        Console.WriteLine($"---- Order Id: {y.OrderID} - Shipper Name: {y.ShipName} - Shipper Region: {y.ShipRegion} - Order Date: {y.OrderDate}");
                    }
                }
                Console.WriteLine("Operacion realizada");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Ocurrio un error con la consulta");
            }
        }
    }
}
