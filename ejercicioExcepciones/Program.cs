using ejercicioExcepciones.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioExcepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = -1;
            //List<Numeros> listaNumeros = new List<Numeros>();

            do
            {
                Console.WriteLine("\n********************************************");
                Console.WriteLine("Ingrese un número de Opción");
                Console.WriteLine("1. Division con Excepcion");
                Console.WriteLine("2. Division con Posible Excepcion");
                Console.WriteLine("3. Disparador de Excepcion");
                Console.WriteLine("4. Disparar Excepcion personalizada");
                Console.WriteLine("0. Salir del programa");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("********************************************\n");
                    switch (opcion)
                    {
                        case 1:
                            {
                                DivisionExcepcion();
                                break;
                            }
                        case 2:
                            {
                                DivisionPosibleExcepcion();
                                break;
                            }
                        case 3:
                            {
                                try
                                {
                                    Logic l = new Logic();
                                    //l.DisparadorExcepcion();
                                    l.NoImplementado();

                                    //throw new NotImplementedException();
                                }
                                catch (NotImplementedException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                        case 4:
                            {
                                try
                                {
                                    Logic l = new Logic();
                                    l.ExcepcionPersonalizada();
                                }
                                catch (NotImplementedException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                        case 0:
                            {
                                Console.WriteLine("Saliendo del programa .........");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Ingrese una opción valida del menú");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un numero de opción valida del menú");
                }

            } while (opcion != 0);
            Console.WriteLine("Fin de la ejecución");
            Console.ReadKey();
        }

        public static void DivisionExcepcion()
        {
            try
            {
                int num, resultado = 0;
                Console.Write("Ingrese un numero: ");
                num = int.Parse(Console.ReadLine());
                resultado = num / 0;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion");
            }

        }

        private static void DivisionPosibleExcepcion()
        {

            try
            {
                int numA, numB, resultado = 0;
                string aux = "";
                Console.Write("Ingrese el primer numero: ");
                aux = Console.ReadLine();
                if (int.TryParse(aux, out numA))
                {
                    Console.Write("Ingrese el segundo numero: ");
                    aux = Console.ReadLine();
                    if (int.TryParse(aux, out numB))
                    {
                        resultado = numA / numB;
                        Console.WriteLine($"{numA} / {numB} = {resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
                    }
                }
                else
                {
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion");
            }
        }

        //    private static void Operacion(List<Numeros> list)
        //    {
        //        bool realizado = false;
        //        string aux = "";
        //        double numero = 0;
        //        Numeros n = new Numeros();

        //        do
        //        {
        //            Console.WriteLine("Ingrese el primer número: ");
        //            aux = Console.ReadLine();
        //            if (double.TryParse(aux, out numero))
        //            {
        //                n.NumA = numero;
        //                numero = 0;
        //                Console.Write("Ingrese el segundo número: ");
        //                aux = Console.ReadLine();
        //                if (double.TryParse(aux, out numero))
        //                {
        //                    n.NumB = numero;
        //                    Console.WriteLine("Ingrese el simbolo de la operación (suma +) (resta -) (multiplicacion *) (division /)");
        //                    aux = "";
        //                    aux += Console.Read();
        //                    switch (aux)
        //                    {
        //                        case "+":
        //                            {
        //                                n.Resultado = OperacionAritmetica.Suma(n.NumA, n.NumB);
        //                                n.Operador = "+";
        //                                break;
        //                            }
        //                        case "-":
        //                            {
        //                                break;
        //                            }
        //                        case "*":
        //                            {
        //                                break;
        //                            }
        //                        case "/":
        //                            {
        //                                break;
        //                            }
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
        //            }

        //        } while (!realizado);
        //    }
    }
}
