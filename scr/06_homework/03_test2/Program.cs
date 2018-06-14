using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_test2
{
    class Program
    {
        static void Main(string[] args)
        {
         
            int kord = 0;
            int võit = 0;

            Console.WriteLine("Tere! Mängime 21 ehk Blackjacki. Kui reegleid ei tea siis googelda!");
            while (true) 
            {
                kord++; 

                Console.WriteLine();

                int mks = 0; 
                int aks = 0; 

                Random lmp = new Random();

                mks += lmp.Next(1, 12); 
                mks += lmp.Next(1, 12); 

                if (mks > 21)
                {
                    mks -= 10; 
                }

                aks += lmp.Next(1, 12); 
                aks += lmp.Next(1, 12);

                if (aks > 21)
                {
                    aks -= 10;
                }

               
                while (true)
                {
                    if (mks == 21)
                    {
                        Console.WriteLine("Said Blackjacki, ehk su summa on 21!");
                        break;
                    }

                    Console.WriteLine("Su summa on praegu " + mks.ToString() + ", kas võtad?");
                    Console.Write("Y või N: ");
                    string yvn = Console.ReadLine();

                    if (yvn == "y")
                    {
                        mks += lmp.Next(1, 12);

                        if (mks > 21)
                        {
                            Console.WriteLine("Sa läksid lõhki, summa üle 21!");
                            break;
                        }

                        else
                        {
                            continue; 
                        }
                    }

                    else if (yvn == "n")
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Vasta kas y või n");
                        continue;
                    }

                }

                Console.WriteLine("Sinu kaardi summa on " + mks.ToString());

                
                if (mks <= 21)
                {
                    while (aks < 21 && aks < mks) 
                    {
                        aks += lmp.Next(1, 12);
                    }

                    if (aks == mks)
                    {
                        Console.WriteLine("Sinu ja arvuti summad on võrtsed. Viik teie vahel.");
                    }

                    else if (aks > mks && aks <= 21)
                    {
                        Console.WriteLine("Arvuti võitis!");
                    }

                    else if (aks > 21)
                    {
                        Console.WriteLine("Arvuti läks lõhki. Sina võitsid!!!");
                        võit++;
                    }

                    else if (aks == 21)
                    {
                        Console.WriteLine("Arvuti võitis!");
                    }
                }

                else
                {
                    Console.WriteLine("Arvuti võit!!");
                }
                Console.WriteLine("Arvuti kaardi summa on " + aks.ToString());

                
                Console.Write("Kas soovid uuesti proovida! Y või N: ");
                string jatk = Console.ReadLine();

                if (jatk == "y")
                {
                    continue; 
                }

                else if (jatk == "n")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Mine magama!");
                    break;
                }

            }

            Console.WriteLine("Mängisid " + kord + " korda!");
            Console.WriteLine("Võitsid " + võit + " korda!");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
