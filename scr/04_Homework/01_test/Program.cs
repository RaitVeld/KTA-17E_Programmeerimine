using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int kiik;
            int.TryParse(Console.ReadLine(), out kiik);

            switch (kiik)
            {
                case 1:
                    Console.WriteLine("test");
                    break;
                case 2:
                    Console.WriteLine("test2");
                    int kaak;
                    int.TryParse(Console.ReadLine(), out kaak);

                    switch (kaak)
                    {
                        case 1:
                            Console.WriteLine("Whaat");
                            break;
                    }                  
                    break;
                case 3:
                    goto surm;

            }

        surm:
            Console.WriteLine("surm");
            Console.ReadLine();
        }
    }
}
