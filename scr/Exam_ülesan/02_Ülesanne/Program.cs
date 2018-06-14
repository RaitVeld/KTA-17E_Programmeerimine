using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Ülesanne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sisesta mingi sõna või lause või ära tee midagi. ");
            Console.WriteLine("Teeme tekstis olevad nime algus tähed suureks.");
            Console.WriteLine();

            string[] nimed = new string[10] { "kaur", "mattias", "kristel", "heleri", "trevor",
                "kristjan", "kelli", "kevin", "maarika", "laura" };

            string userInput = Console.ReadLine();            

            for (int i = 0; i < nimed.Count(); i++)
            {
                userInput = userInput.Replace(nimed[i], SuurNimi(nimed[i]));
            }

            Console.WriteLine(userInput);
            Console.ReadLine();
        }

        static string SuurNimi(string nimi)
        {
            if (nimi.Length == 1)
                return nimi.ToUpper();
            return nimi.Remove(1).ToUpper() + nimi.Substring(1);
        }
    }
}
