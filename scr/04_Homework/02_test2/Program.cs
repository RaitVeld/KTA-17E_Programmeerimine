using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_test2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string teststring = Console.ReadLine();

            string teststring2 = teststring.Replace("a", "g");

            Console.WriteLine(teststring2);
            Console.ReadLine();
        }
    }
}
