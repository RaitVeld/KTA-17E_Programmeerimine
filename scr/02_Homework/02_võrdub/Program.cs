using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_võrdub
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnum = 4;

            Console.WriteLine("Valin ühe numbri vahemikust [1-100]. Arva ära!");
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
