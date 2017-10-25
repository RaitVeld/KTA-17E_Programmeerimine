using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_count_tries
{
    class Program
    {
        static void Main(string[] args)
        {
            Random lamp = new Random();
            int cnum = lamp.Next(1, 101);
            int num = 0;
            int tnum = 0;

            Console.WriteLine("Valin suvaliselt ühe numbri vahemikus [1-100]. Proovi ära arvata");

            while (true)
            {
                Console.Write("Sinu number: ");
                int.TryParse(Console.ReadLine(), out num);
                tnum++;

                if (cnum == num)
                {
                    Console.WriteLine();
                    Console.WriteLine("Tubli! Ära arvasid!");
                    Console.WriteLine($"Kõigest {tnum} korda!");
                    break;
                }

                if (cnum < num)
                {
                    Console.WriteLine();
                    Console.WriteLine("Minu number on väiksem kui " + num);
                }
                 if (cnum > num)
                {
                    Console.WriteLine();
                    Console.WriteLine("Minu number on suurem kui " + num);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
