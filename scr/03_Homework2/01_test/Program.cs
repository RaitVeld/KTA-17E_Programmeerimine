using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_blackjack_21
{
    class Program
    {
        static void Main(string[] args)
        {
            // Programm on lihtne versioon kaardi/hasart mängust nagu 21 ehk Blackjack.
            int kord = 0;
            int võit = 0;

            Console.WriteLine("Tere! Mängime 21 ehk Blackjacki. Kui reegleid ei tea siis googelda!");
            while (true) //Kõik kood on while tsüklis, et annaks mängijale võimaluse lõpus uuesti mängid, nii kaua kui soovib
            {
                kord++; // Iga kord kui tsükkel hakkab lisab 1 juurde

                Console.WriteLine();

                int mks = 0; // Peavad jääma tsükkli sisse, muidu jääbki liitma summasid
                int aks = 0; // Nullivad kaartide summad

                Random lmp = new Random();

                mks += lmp.Next(1, 12); // Kasutades sümbolite kombot +=, lisab see random arvu eelmisele väärtusele juurde
                mks += lmp.Next(1, 12); // Kaardi mängus tõmmatakse algul 2 kaarti. Selleks on lisatud kaks rida random liitmist

                if (mks > 21)
                {
                    mks -= 10; // Kuna mängus on ässal kas väärtust 1 või 11, ei saa kunagi mängu alguses summa ületada 21
                }

                aks += lmp.Next(1, 12); // Mängu mängitakse diileri vastu, selleks on meil arvuti(väike koodi jupp)
                aks += lmp.Next(1, 12);

                if (aks > 21)
                {
                    aks -= 10;
                }

                //Mängija mängib selles osas
                while (true)
                {
                    if (mks == 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Muudab teksti värvi. Praegusel juhul punaseks
                        Console.WriteLine("Said Blackjacki, ehk su summa on 21!");
                        Console.ResetColor(); // Taastab kõik teksti värvid
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
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Sa läksid lõhki, summa üle 21!");
                            Console.ResetColor();
                            break;
                        }

                        else
                        {
                            continue; // Lisa funktsioon mille õpisin. Selle sees olevas tsükli algusesse
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

                // Siit algab siis Diileri kord
                if (mks <= 21)
                {
                    while (aks < 21 && aks < mks) //Annan kaks tingimust millal lõpetada tsükkel
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

                //Mängija võimalus jätkata või lõpetada mängimine
                Console.Write("Kas soovid uuesti proovida! Y või N: ");
                string jatk = Console.ReadLine();

                if (jatk == "y")
                {
                    continue; // Läheb kõige esimese While tsükli täielikku algusesse
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
