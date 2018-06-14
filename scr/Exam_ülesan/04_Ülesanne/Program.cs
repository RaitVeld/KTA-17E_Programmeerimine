using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _090418_eksam_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> times = GenerateTimestamps(30, 2010, 1940);

            int oldest = FindOldest(times);
            int average = FindAverage(times);
            int youngest = MinAge(times);
            int theMonth = SpecialMonth(times);

            List<DateTime> orderedTimes = OrderDates(times);

            Console.WriteLine($"Kõige vanem:{oldest}");
            Console.WriteLine($"Kõige noorem:{youngest}");
            Console.WriteLine($"Keskmine vanus:{average}");
            Console.WriteLine($"Kõige tihedam kuu:{theMonth}");

            Console.WriteLine();


            Console.ReadKey();
        }

        static List<DateTime> GenerateTimestamps(int amount, int maxY, int minY)
        {
            int[] monthMax = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Random rnd = new Random();
            int month, day, year;

            List<DateTime> times = new List<DateTime>();
            for (int i = 0; i <= amount; i++)
            {
                year = rnd.Next(minY, maxY);
                month = rnd.Next(1, 13);
                if (DateTime.IsLeapYear(year) && month == 2)
                {
                    day = rnd.Next(1, 29);
                }
                else
                {
                    day = rnd.Next(1, monthMax[month - 1]);
                }

                times.Add(new DateTime(year, month, day));
            }
            return times;
        }

        static int FindOldest(List<DateTime> times)
        {
            int age = 10, maxAge = 0;

            for (int i = 0; i < times.Count(); i++)
            {
                age = GetAge(times[i]);

                if (maxAge < age)
                    maxAge = age;
            }

            return maxAge;
        }

        static int FindAverage(List<DateTime> times)
        {
            int average = 0;

            for (int i = 0; i < times.Count; i++)
            {
                average += GetAge(times[i]);
            }
            average /= times.Count;

            return average;
        }

        static int GetAge(DateTime time)
        {

            int age = DateTime.Now.Year - time.Year;

            return age;
        }

        static int MinAge(List<DateTime> times)
        {
            int minAge = 100;

            for (int i = 0; i < times.Count; i++)
            {
                if (minAge > GetAge(times[i]))
                    minAge = GetAge(times[i]);
            }
            return minAge;
        }

        static int SpecialMonth(List<DateTime> times)
        {
            int theMonth = 0;
            int[] monthList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < times.Count; i++)
            {
                monthList[times.ElementAt(i).Month - 1]++;
            }

            for (int i = 0; i < monthList.Count(); i++)
            {
                if (monthList[i] > theMonth)
                    theMonth = monthList[i];
            }
            return theMonth;
        }

        static List<DateTime> OrderDates(List<DateTime> times)
        {
            List<DateTime> orderedTimes = times.OrderBy(x => x.TimeOfDay).ToList();



            return orderedTimes;

        }
    }
}