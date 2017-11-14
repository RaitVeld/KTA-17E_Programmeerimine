using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {//magic 8ball
            while (true)
            {
                string[] vastus = new string[5] { "JAH", "EI", "MA EI TEA", "PIGEM EI", "VÕIBOLLA" };

                Random lmp = new Random();
                int shake = lmp.Next(0, 5);

                Console.WriteLine("Vastan sinu kas küsimustele!");
                Console.ReadLine();

                Console.WriteLine(vastus[shake]);

                Console.Write("Kas jätkad? y või n: ");
                string ots = Console.ReadLine();
                if (ots == "y") continue;
                
                else break;
                
            }
        }
    }
}
