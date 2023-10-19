using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("***     Examen 1     ***\n*** Angelo Chavarria ***\nPresione cualquier tecla para iniciar...");
            Console.ReadKey();
            Console.Clear(); 
            ClsMenu.Desplegar();
        }
    }
}
