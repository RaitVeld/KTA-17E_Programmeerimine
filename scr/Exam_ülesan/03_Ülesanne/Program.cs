using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Ülesanne
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            DateTime GetRandomDate(DateTime uks, DateTime kaks)
            {
                int vahe_days = (kaks - uks).Days;

                return uks.AddDays(rnd.NextDouble() * vahe_days);
            }

            Console.WriteLine("Timestampi generaator 3000");
            Console.WriteLine();

            Console.Write("Miinimum aasta: ");
            int min_a = int.Parse(Console.ReadLine());

            Console.Write("Maksimum aasta: ");
            int max_a = int.Parse(Console.ReadLine());

            Console.Write("Kogus: ");
            int hulk = int.Parse(Console.ReadLine());

            int a_vahe = max_a - min_a;

            DateTime uks_a = new DateTime(min_a, 1, 1);
            DateTime kaks_a = new DateTime(max_a, 12, 31);

            Console.WriteLine("Timestamps: ");

            do
            {
                Console.WriteLine(GetRandomDate(uks_a, kaks_a));
                hulk--;
            }
            while (hulk > 0);

            Console.ReadLine();
        }
    }
}
