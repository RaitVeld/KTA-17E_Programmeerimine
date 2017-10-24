using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_random
{
    class Program
    {
        static void Main(string[] args)
        {
            Random lamp = new Random();
            int cnum = lamp.Next(1, 101);

            Console.WriteLine("Valin ühe suvalise numbri vahemikust [1-100]. Proovi ära arvata!");
            Console.Write("Sinu number: ");
            string input = Console.ReadLine();
            int num = int.Parse(input);

            if (cnum == num)
            {
                Console.WriteLine();
                Console.WriteLine("Tubli! Arvasid ära!");
            }

            if (cnum < num)
            {
                Console.WriteLine();
                Console.WriteLine("Minu number on väiksem!");
            }

            if (cnum > num)
            {
                Console.WriteLine();
                Console.WriteLine("Minu number on suurem!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
