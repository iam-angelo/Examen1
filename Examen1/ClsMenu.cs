using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class ClsMenu
    {
        private static int opcion = 0;

        //constructor

        public ClsMenu() { }

        public static void Desplegar()
        {
            do
            {
                Console.WriteLine("1: Agregar Empleados");
                Console.WriteLine("2: Consultar Empleados");
                Console.WriteLine("3: Modificar Empleados");
                Console.WriteLine("4: Borrar Empleados");
                Console.WriteLine("5: Inicializar Empleados");
                Console.WriteLine("6: Reportes");
                Console.WriteLine("7: Salir");

                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 1: ClsMenu.Agregar(); break;
                    case 2: ClsMenu.Consultar(); break;
                    case 3: ClsMenu.Modificar(); break;
                    case 4: ClsMenu.Borrar(); break;
                    case 5: ClsMenu.Inicializar(); break;
                    case 6: ClsMenu.Submenu();break;
                    case 7: break;
                    default:
                        Console.WriteLine("Ingrese un caracter valido");
                        break;
                }
            } while (opcion != 7);
        }

        public static void Inicializar()
        {
            Console.Clear();
            ClsEmpleado.cedula = Enumerable.Repeat("", ClsEmpleado.cantidad).ToArray();
            ClsEmpleado.nombre = Enumerable.Repeat("", ClsEmpleado.cantidad).ToArray();
            ClsEmpleado.direccion = Enumerable.Repeat("", ClsEmpleado.cantidad).ToArray();
            ClsEmpleado.phone = Enumerable.Repeat("", ClsEmpleado.cantidad).ToArray();
            ClsEmpleado.salario = Enumerable.Repeat(0f, ClsEmpleado.cantidad).ToArray();
            Console.WriteLine("***Inicializado con exito***\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Agregar()
        {
            Console.Clear();
            for (int i = 0; i < ClsEmpleado.cantidad; i++)
            {
                Console.Clear();
                Console.Write("Digite la cedula {0}: ", i + 1);
                ClsEmpleado.cedula[i] = Console.ReadLine();
                Console.Write("Digite el nombre {0}: ", i + 1);
                ClsEmpleado.nombre[i] = Console.ReadLine();
                Console.Write("Digite la direccion {0}: ", i + 1);
                ClsEmpleado.direccion[i] = Console.ReadLine();
                Console.Write("Digite el telefono {0}: ", i + 1);
                ClsEmpleado.phone[i] = Console.ReadLine();
                Console.Write("Digite el salario {0}: ", i + 1);
                ClsEmpleado.salario[i] = float.Parse(Console.ReadLine());
            }
        }
        static int Buscar()
        {
            Console.WriteLine("Digite la Cedula: ");
            string id = Console.ReadLine();
            bool encontrado = false;
            int indice = -1;

            for (int i = 0; i < ClsEmpleado.cantidad; i++)
            {
                if (id.Equals(ClsEmpleado.cedula[i]))
                {
                    indice = i;
                    encontrado = true;
                }
            }
            if (encontrado == false)
            {
                Console.WriteLine($"No se encontraron resultados");
            }

            return indice;
        }

        public static void Consultar()
        {
            int indice = Buscar();
            Console.Clear();
            if (indice >= 0)
            {
                Console.WriteLine($"Nombre: {ClsEmpleado.nombre[indice]}");
                Console.WriteLine($"Cedula: {ClsEmpleado.cedula[indice]}");
                Console.WriteLine($"Direccion: {ClsEmpleado.direccion[indice]}");
                Console.WriteLine($"Telefono: {ClsEmpleado.phone[indice]}");
                Console.WriteLine($"Salario: {ClsEmpleado.salario[indice]}");
            }
        }
        public static void Modificar()
        {
            Console.Clear();
            int indice = Buscar();

            if (indice >= 0)
            {
                Console.WriteLine($"Nombre Actual: {ClsEmpleado.nombre[indice]}");
                Console.Write("Digite Nuevo nombre: ");
                ClsEmpleado.nombre[indice] = Console.ReadLine();

                Console.WriteLine($"Direccion Actual: {ClsEmpleado.direccion[indice]}");
                Console.Write("Digite Direccion Nueva: ");
                ClsEmpleado.direccion[indice] = Console.ReadLine();

                Console.WriteLine($"Salario Actual: {ClsEmpleado.salario[indice]}");
                Console.Write("Digite Nuevo Salario: ");
                float.TryParse(Console.ReadLine(), out ClsEmpleado.salario[indice]);
                

                Console.WriteLine($"Telefono Actual: {ClsEmpleado.phone[indice]}");
                Console.Write("Digite nuevo Telefono: ");
                ClsEmpleado.phone[indice] = Console.ReadLine();
            }
        }
        public static void Borrar()
        {
            Console.Clear();
            int indice = Buscar();
            if (indice >= 0)
            {
                Console.WriteLine($"Eliminando la cedula: {ClsEmpleado.cedula[indice]}");
                ClsEmpleado.cedula[indice] = string.Empty;
                ClsEmpleado.nombre[indice] = string.Empty;
                ClsEmpleado.direccion[indice] = string.Empty;
                ClsEmpleado.phone[indice] = string.Empty;
                ClsEmpleado.salario[indice] = 0f;
                Console.WriteLine("***Eliminado con exito***\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void Submenu()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("1: Consultar Empleado");
                Console.WriteLine("2: Nombres de Empleados");
                Console.WriteLine("3: Promedio de los salarios");
                Console.WriteLine("4: Salario mas alto y mas bajo");
                Console.WriteLine("5: Salir");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        ClsMenu.Consultar();
                        break;
                    case 2:
                        ClsMenu.ReportarTodos();
                        break;
                    case 3:
                        ClsMenu.PromedioSal();
                        break;
                    case 4:
                        ClsMenu.SalarioHL();
                        break;
                    default:
                        break;
                }
            } while (opcion != 5);
        }
        public static void ReportarTodos()
        {
            Console.Clear();
            string[] orden = ClsEmpleado.nombre;
            Array.Sort(orden);
            foreach (string orde in orden)
            {
                Console.WriteLine(orde);
            }

        }

        public static void PromedioSal()
        {
            Console.Clear();
            double prom = ClsEmpleado.salario.Average();
            Console.WriteLine($"El Promedio de los salarios es: {prom}");
        }
        public static void SalarioHL()
        {
            Console.Clear();
            double mayor = ClsEmpleado.salario.Max();
            double menor = ClsEmpleado.salario.Min();

            Console.WriteLine("El Salario mas alto es: {0}", mayor);
            Console.WriteLine("El Salario menor es: {0}", menor);
        }
    }
}
