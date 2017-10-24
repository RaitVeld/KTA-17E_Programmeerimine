using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_suure_või_väiksem
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnum = 23;

            Console.WriteLine("Ma valin ühe numbri vahemikust [1-100]. Proovi ära arvata!");
            Console.Write("Sinu number: ");
            string input = Console.ReadLine();
            int num = int.Parse(input);
            
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
