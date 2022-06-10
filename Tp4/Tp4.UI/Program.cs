using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp4.Entities;
using Tp4.Logic;

namespace Tp4.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = -1;
            string respuesta = "";

            do
            {
                Console.WriteLine("\n********************************************");
                Console.WriteLine("Ingrese un número de Opción");
                Console.WriteLine("1. Cargar un Expedidor");
                Console.WriteLine("2. Buscar un Expedidor");
                Console.WriteLine("3. Ver Listado de Expedidores");
                Console.WriteLine("4. Modificar un Expedidor");
                Console.WriteLine("5. Eliminar un Expedidor");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("6. Cargar una Categoria");
                Console.WriteLine("7. Buscar una Categoria");
                Console.WriteLine("8. Ver Listado de Categorias");
                Console.WriteLine("9. Modificar una Categoria");
                Console.WriteLine("10. Eliminar una Categoria");
                Console.WriteLine("0. Salir");
                Console.Write("Respuesta: ");
                respuesta = Console.ReadLine();
                if (!int.TryParse(respuesta, out opcion))
                {
                    opcion = -1;
                }

                Console.WriteLine("********************************************\n");

                switch (opcion)
                {
                    case 1:
                        {
                            Agregar(1);
                            break;
                        }
                    case 2:
                        {
                            VerUno(1);
                            break;
                        }
                    case 3:
                        {
                            VerListado(1);
                            break;
                        }
                    case 4:
                        {
                            ModificarUno(1);
                            break;
                        }
                    case 5:
                        {
                            EliminarUno(1);
                            break;
                        }
                    case 6:
                        {
                            Agregar(2);
                            break;
                        }
                    case 7:
                        {
                            VerUno(2);
                            break;
                        }
                    case 8:
                        {
                            VerListado(2);
                            break;
                        }
                    case 9:
                        {
                            ModificarUno(2);
                            break;
                        }
                    case 10:
                        {
                            EliminarUno(2);
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
        public static void Agregar(int tipo)
        {
            int id = 0;
            switch (tipo)
            {
                case 1:
                    {
                        string compName = "";
                        string phone = "";
                        Console.Write("Ingrese el nombre de la compañia: ");
                        compName = Console.ReadLine();
                        Console.Write("Ingrese el numero de telefono: ");
                        phone = Console.ReadLine();
                        try
                        {
                            ShippersLogic shippersLogic = new ShippersLogic();
                            id = shippersLogic.FindLastIndex();
                            shippersLogic.Add(new Shippers
                            {
                                ShipperID = id + 1,
                                CompanyName = compName,
                                Phone = phone
                            });
                            Console.WriteLine("Se ha agregado con éxito !!!");
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("No se pudo agregar");
                        }

                        break;
                    }
                case 2:
                    {
                        string catName = "";
                        string descrip = "";
                        Console.Write("Ingrese el nombre de la categoria: ");
                        catName = Console.ReadLine();
                        Console.Write("Ingrese la descripcion: ");
                        descrip = Console.ReadLine();
                        try
                        {
                            CategoriesLogic categoriesLogic = new CategoriesLogic();
                            id = categoriesLogic.FindLastIndex();
                            categoriesLogic.Add(new Categories
                            {
                                CategoryID = id + 1,
                                CategoryName = catName,
                                Description = descrip
                            });
                            Console.WriteLine("Se ha agregado con éxito !!!");
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("No se pudo agregar");
                        }                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No se encontro la opcion :(");
                        break;
                    }
            }
        }
        public static void VerListado(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    {
                        ShippersLogic shippersLogic = new ShippersLogic();
                        foreach (Shippers s in shippersLogic.GetAll())
                        {
                            Console.WriteLine($"Id: {s.ShipperID} - Nombre de Compañia: {s.CompanyName} - Teléfono: {s.Phone}");
                        }
                        break;
                    }
                case 2:
                    {
                        CategoriesLogic categoriesLogic = new CategoriesLogic();
                        foreach (Categories c in categoriesLogic.GetAll())
                        {
                            Console.WriteLine($"ID: {c.CategoryID} - Nombre: {c.CategoryName} - Descirpcion: {c.Description}");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No se encontro la opción :(");
                        break;
                    }
            }
        }
        public static void VerUno(int tipo)
        {
            string respuesta = "";
            int idBuscado = 0;
            switch (tipo)
            {
                case 1:
                    {
                        Console.Write("Ingrese el ID: ");
                        respuesta = Console.ReadLine();
                        if (int.TryParse(respuesta, out idBuscado))
                        {
                            ShippersLogic shippersLogic = new ShippersLogic();
                            Shippers s = shippersLogic.FindOne(idBuscado);
                            if (s != null)
                            {
                                Console.WriteLine($"Id: {s.ShipperID} - Nombre de Compañia: {s.CompanyName} - Teléfono: {s.Phone}");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un ID válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un ID válido");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Ingrese el ID: ");
                        respuesta = Console.ReadLine();
                        if (int.TryParse(respuesta, out idBuscado))
                        {
                            CategoriesLogic categoriesLogic = new CategoriesLogic();
                            Categories c = categoriesLogic.FindOne(idBuscado);
                            if (c != null)
                            {
                                Console.WriteLine($"ID: {c.CategoryID} - Nombre: {c.CategoryName} - Descirpcion: {c.Description}");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un ID válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un ID válido");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No se encontro la opción :(");
                        break;
                    }
            }
        }
        public static void ModificarUno(int tipo)
        {
            string respuesta = "";
            int idBuscado = 0;
            switch (tipo)
            {
                case 1:
                    {
                        Console.Write("Ingrese el Id del Expedidor a modificar: ");
                        respuesta = Console.ReadLine();
                        if (int.TryParse(respuesta, out idBuscado))
                        {
                            ShippersLogic shippersLogic = new ShippersLogic();
                            Shippers s = new Shippers();
                            var originalShipper = shippersLogic.FindOne(idBuscado);
                            if (originalShipper != null)
                            {
                                s.ShipperID = originalShipper.ShipperID;
                                Console.Write("Ingrese el nombre de la compañia (presione enter para omitir): ");
                                s.CompanyName = Console.ReadLine();
                                Console.Write("Ingrese el telefono (ingrese '-' para omitir): ");
                                s.Phone = Console.ReadLine();
                                shippersLogic.Update(s);
                                Console.WriteLine("Se modificó con exito");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un ID válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un ID válido");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Ingrese el Id de la Categoria a modificar: ");
                        respuesta = Console.ReadLine();
                        if (int.TryParse(respuesta, out idBuscado))
                        {
                            CategoriesLogic categoriesLogic = new CategoriesLogic();
                            Categories c = new Categories();
                            var originalCategory = categoriesLogic.FindOne(idBuscado);
                            if (originalCategory != null)
                            {
                                c.CategoryID = originalCategory.CategoryID;
                                Console.Write("Ingrese el nombre de la categoria (presione enter para omitir): ");
                                c.CategoryName = Console.ReadLine();
                                Console.Write("Ingrese la descripción (ingrese '-' para omitir): ");
                                c.Description = Console.ReadLine();
                                categoriesLogic.Update(c);
                                Console.WriteLine("Se modificó con exito");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un ID válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un ID válido");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No se encontro la opción :(");
                        break;
                    }
            }
        }
        public static void EliminarUno(int tipo)
        {
            int idBuscado = 0;
            string respuesta = "";
            switch (tipo)
            {
                case 1:
                    {
                        Console.Write("Ingrese el Id del Expedidor a eliminar: ");
                        respuesta = Console.ReadLine();
                        if (int.TryParse(respuesta, out idBuscado))
                        {
                            ShippersLogic shippersLogic = new ShippersLogic();
                            if (shippersLogic.Exist(idBuscado))
                            {
                                shippersLogic.Delete(idBuscado);
                                Console.WriteLine("Operación Realizada");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un ID válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un ID válido");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Ingrese el Id de la Categoria a eliminar: ");
                        respuesta = Console.ReadLine();
                        if (int.TryParse(respuesta, out idBuscado))
                        {
                            CategoriesLogic categoriesLogic = new CategoriesLogic();
                            if (categoriesLogic.Exist(idBuscado))
                            {
                                categoriesLogic.Delete(idBuscado);
                                Console.WriteLine("Operación Realizada");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un ID válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un ID válido");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No se encontro la opción :(");
                        break;
                    }
            }
        }
    }
}
