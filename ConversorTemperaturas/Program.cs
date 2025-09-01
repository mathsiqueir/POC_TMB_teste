using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorTemperaturas
{
    class Program
    {
        static void Main(string[] args) {
         
       

            int[ , ] numerosb = new int[3, 3];

            numerosb[0, 0] = 10;
            numerosb[0, 1] = 20;
            numerosb[0, 2] = 30;

            numerosb[1, 0] = 40;
            numerosb[1, 1] = 40;
            numerosb[1, 2] = 60;
             
            numerosb[2, 0] = 70;
            numerosb[2, 1] = 70;
            numerosb[2, 2] = 70;

            Console.Write("[" + numerosb[0,0] + "]");
            Console.Write("[" + numerosb[0,1] + "]");
            Console.Write("[" + numerosb[0,2] + "]");

            Console.WriteLine();
            Console.Write("[" + numerosb[1,0] + "]");
            Console.Write("[" + numerosb[1,1] + "]");
            Console.Write("[" + numerosb[1,2] + "]");

        }
    }
}
