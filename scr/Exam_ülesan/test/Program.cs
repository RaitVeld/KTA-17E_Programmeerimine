using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksami_harjutus04
{
    public class Program
    {

        static void Main(string[] args)
        {

         

            ArrayList al = new ArrayList();    

            al.Add(new DateTime(1969, 08, 23, 17, 22, 31));
            al.Add(new DateTime(1966, 03, 31, 11, 45, 29));
            al.Add(new DateTime(2002, 10, 22, 17, 41, 16));
            al.Add(new DateTime(1981, 06, 03, 04, 23, 38));
            al.Add(new DateTime(1949, 08, 03, 12, 47, 53));
            al.Add(new DateTime(1949, 09, 17, 15, 46, 03));
            al.Add(new DateTime(1990, 03, 12, 03, 08, 45));
            al.Add(new DateTime(1970, 12, 26, 06, 36, 35));
            al.Add(new DateTime(2007, 10, 19, 07, 29, 55));
            al.Add(new DateTime(1964, 03, 17, 13, 46, 43));
            al.Add(new DateTime(1965, 03, 16, 19, 41, 46));
            al.Add(new DateTime(1975, 02, 02, 00, 36, 19));
            al.Add(new DateTime(1965, 12, 20, 10, 45, 29));
            al.Add(new DateTime(1994, 08, 22, 06, 50, 10));
            al.Add(new DateTime(1981, 12, 07, 16, 29, 23));
            al.Add(new DateTime(1962, 04, 16, 02, 52, 24));
            al.Add(new DateTime(2005, 08, 29, 09, 10, 19));
            al.Add(new DateTime(1979, 11, 20, 23, 41, 21));
            al.Add(new DateTime(2004, 12, 18, 08, 45, 47));
            al.Add(new DateTime(1996, 04, 28, 16, 50, 29));
            al.Add(new DateTime(1942, 06, 22, 11, 15, 52));
            al.Add(new DateTime(2007, 12, 03, 03, 12, 41));
            al.Add(new DateTime(1962, 09, 01, 19, 28, 21));
            al.Add(new DateTime(1953, 08, 25, 10, 08, 06));
            al.Add(new DateTime(1999, 02, 20, 16, 34, 59));
            al.Add(new DateTime(1993, 12, 29, 01, 25, 48));
            al.Add(new DateTime(2005, 06, 12, 09, 47, 04));
            al.Add(new DateTime(2008, 04, 02, 07, 49, 49));
            al.Add(new DateTime(2010, 06, 18, 18, 16, 36));
            al.Add(new DateTime(1972, 08, 08, 23, 03, 32));








            int[] numbers = new int[24] { 1940, 1945, 1949, 1953, 1955, 1963, 1966, 1970, 1972, 1976, 1976, 1979, 1980, 1985, 1988, 1996, 1997, 1999, 2000, 2006, 2008, 2008, 2009, 2010 };



            int sum = 1940 + 1945 + 1949 + 1953 + 1955 + 1963 + 1966 + 1970 + 1972 + 1976 + 1976 + 1979 + 1980 + 1985 + 1988 + 1996 + 1997 + 1999 + 2000 + 2006 + 2008 + 2008 + 2009 + 2010;
            int arv = 24;
            int keskmine = sum / arv;

            int min_vanus = 2018 - numbers.Min();
            int max_vanus = 2018 - numbers.Max();
            int mid_vanus = 2018 - keskmine;

            Console.WriteLine("Min vanus: {0}", max_vanus);
            Console.WriteLine("Max vanus: {0}", min_vanus);
            Console.WriteLine("Kesk vanus: {0}", mid_vanus);

            

            int[] array = new int[24] { 01, 05, 12, 07, 05, 02, 10, 06, 05, 05, 02, 05, 06, 07, 11, 12, 08, 04, 10, 09, 01, 09, 11, 05 };
            int count = 1, tempCount;
            int korrad = array[0];
            int Number = 0;
            for (int i = 0; i < (array.Length - 1); i++)
            {
                Number = array[i];
                tempCount = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (Number == array[j])
                    {
                        tempCount++;
                    }
                }
                if (tempCount > count)
                {
                    korrad = Number;
                    count = tempCount;
                }
            }
            Console.WriteLine("Sagedasem kuu : {0}, sel kuul on {1} inimesel sünnipäev.", korrad, count);

           

            Console.WriteLine();
            Console.WriteLine("Sorteeritud:");
            Console.WriteLine();

            

            foreach (DateTime i in al)
            {
                
                Console.WriteLine((i) + " ");
            }

            


            Console.ReadLine();

        }
    }
}