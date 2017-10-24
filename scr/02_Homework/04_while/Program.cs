using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_while
{
    class Program
    {
        static void Main(string[] args)
        {
            Random lamp = new Random();
            int cnum = lamp.Next(1, 101);
            int num = 0;

            Console.WriteLine("Valin ühe suvalise numbri vahemikust [1-100]. Proovi ära arvata!");
            
            while (cnum != num)
            {
                Console.WriteLine();
                Console.Write("Sinu number: ");
                int.TryParse(Console.ReadLine(), out num);

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
            Console.WriteLine("Tubil! Ära arvasid!");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
