using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Tunnikontroll
{
    class Program
    {
        static void Main(string[] args)
        {
            int summa;
            Console.WriteLine("See on soodustuse programm.");
            Console.Write("Sisesta summa: ");
            int.TryParse(Console.ReadLine(), out summa);
            Console.WriteLine();

            if (summa >= 50 && summa < 250)
            {
                double sumt = (summa * 0.9);
                double sump = (summa * 0.8);

                Console.WriteLine("Summa: " + summa);
                Console.WriteLine("Tavaklient:");
                Console.WriteLine("Allahindlus: 10%");
                Console.WriteLine("Tasuda: " + sumt);
                Console.WriteLine();
                Console.WriteLine("Püsiklient:");
                Console.WriteLine("Allahindlus: 20%");
                Console.WriteLine("Tasuda: " + sump);
            }

            if (summa >= 250 && summa < 350)
            {
                double sumt = (summa * 0.8);
                double sump = (summa * 0.7);

                Console.WriteLine("Summa: " + summa);
                Console.WriteLine("Tavaklient:");
                Console.WriteLine("Allahindlus: 20%");
                Console.WriteLine("Tasuda: " + sumt);
                Console.WriteLine();
                Console.WriteLine("Püsiklient:");
                Console.WriteLine("Allahindlus: 30%");
                Console.WriteLine("Tasuda: " + sump);
            }

            if (summa > 350)
            {
                double sumt = (summa * 0.7);
                double sump = (summa * 0.6);

                Console.WriteLine("Summa: " + summa);
                Console.WriteLine("Tavaklient:");
                Console.WriteLine("Allahindlus: 30%");
                Console.WriteLine("Tasuda: " + sumt);
                Console.WriteLine();
                Console.WriteLine("Püsiklient:");
                Console.WriteLine("Allahindlus: 40%");
                Console.WriteLine("Tasuda: " + sump);
            }

            else
            {
                Console.WriteLine("Soodustus puudub");
                Console.WriteLine("Tasuda: " + summa);
            }

            Console.ReadLine();
        }
    }
}
