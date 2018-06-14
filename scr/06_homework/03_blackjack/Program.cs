using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_blackjack
{
    class Program
    {
        static Mangija[] mangijad = new Mangija[5];
        static int top = 0;
        class Kaart
        {
            public string Mast;
            public int Vaartus;
            public int Punkt;

            public Kaart(int M, int V)
            {
                Vaartus = V;
                switch (M)
                {
                    case 1:
                        Mast = "C";
                        break;
                    case 2:
                        Mast = "D";
                        break;
                    case 3:
                        Mast = "S";
                        break;
                    case 4:
                        Mast = "H";
                        break;
                }

                if (Vaartus > 10)
                {
                    Punkt = 10;
                }
                else if (Vaartus == 1)
                {
                    Punkt = 11;
                }
                else
                {
                    Punkt = Vaartus;
                }
            }
        }

        class Mangija
        {
            public Kaart[] kasi;
            public int kk;
            public int punkt;

            public Mangija()
            {
                kasi = new Kaart[5];
                kk = 0;
                punkt = 0;
            }

        }

        static Kaart[] genPakk()
        {
            Kaart[] Pakk = new Kaart[52];
            int lugeja = 0;

            for (int mast = 1; mast < 5; mast++)
            {
                for (int vaartus = 1; vaartus < 14; vaartus++ )
                {
                    Pakk[lugeja] = new Kaart(mast, vaartus);
                    lugeja++;
                }
            }

            return Pakk;
        }

        static void suffPakk(ref Kaart[] Pakk)
        {
            Random lamp = new Random();
            Kaart temp;
            int num;

            for (int i = 0; i < Pakk.Length; i++)
            {
                num = lamp.Next(0, Pakk.Length);

                temp = Pakk[i];
                Pakk[i] = Pakk[num];
                Pakk[num] = temp;
            }
        }

        static void KaartSymbol(Kaart kaart)
        {
            switch (kaart.Vaartus)
            {
                case 1:
                    Console.Write("A{0}", kaart.Mast);
                    break;
                case 11:
                    Console.Write("J{0}", kaart.Mast);
                    break;
                case 12:
                    Console.Write("Q{0}", kaart.Mast);
                    break;
                case 13:
                    Console.Write("K{0}", kaart.Mast);
                    break;
                default:
                    Console.Write("{0}{1}", kaart.Vaartus, kaart.Mast);
                    break;
            }
        }

        static void opKasi(Mangija mangija)
        {
            Console.Write("Sinu kaardid: ");

            for (int i = 0; i < mangija.kk; i++)
            {
                KaartSymbol(mangija.kasi[i]);
            }
        }

        static void opKasi2(Mangija mangija)
        {
            Console.Write("Arvuti kaardid: ");
            KaartSymbol(mangija.kasi[0]);
            
        }

        static void tKasi(Kaart[] Pakk, ref Mangija mangija)
        {
            Kaart jkaart = Pakk[top];

            if (mangija.kk < 5)
            {
                mangija.kasi[mangija.kk] = jkaart;
                mangija.kk++;
                mangija.punkt += jkaart.Punkt;
                top++;
            }

        }

        static bool kontrollPunkt(Mangija mangija)
        {
            if (mangija.punkt > 21)
            {
                Console.WriteLine("Lõhki!");
                return false;
            }

            return true;
        }

        static void voitjaArv(Mangija mangija, Mangija arvuti)
        {
            if (arvuti.punkt > 21 || mangija.kk == 5 && arvuti.kk != 5)
            {
                Console.WriteLine("Sinu punktid {0}, arvuti punktid {1}", mangija.punkt, arvuti.punkt);
                Console.WriteLine("Sinu võit!");
            }
            else if (arvuti.punkt == mangija.punkt)
            {
                Console.WriteLine("Sinu punktid {0}, arvuti punktid {1}", mangija.punkt, arvuti.punkt);
                Console.WriteLine("Viik!");
            }
            else if (arvuti.punkt == 21 && mangija.punkt != 21 || mangija.kk < 5)
            {
                Console.WriteLine("Sinu punktid {0}, arvuti punktid {1}", mangija.punkt, arvuti.punkt);
                Console.WriteLine("Kaotasid!");
            }
            else if (mangija.kk == 5 && arvuti.kk == 5)
            {
                if (mangija.punkt > arvuti.punkt)
                {
                    Console.WriteLine("Sinu punktid {0}, arvuti punktid {1}", mangija.punkt, arvuti.punkt);
                    Console.WriteLine("Võit!");
                }

                else if (mangija.punkt == arvuti.punkt)
                {
                    Console.WriteLine("Sinu punktid {0}, arvuti punktid {1}", mangija.punkt, arvuti.punkt);
                    Console.WriteLine("Viik!");
                }
                Console.WriteLine("Sinu punktid {0}, arvuti punktid {1}", mangija.punkt, arvuti.punkt);
                Console.WriteLine("Kaotasid");
            }
        }

        static void kontAss(ref Mangija mangija)
        {
            bool changed = false;
            if (mangija.punkt > 21)
            {
                for (int i = 0; i < mangija.kk; i++)
                {
                    if (mangija.kasi[i].Punkt == 11 && changed == false)
                    {
                        mangija.kasi[i].Punkt = 1;
                        mangija.punkt -= 10;
                        changed = true;
                    }
                }
            }

        }

        static void sMang()
        {
            string Uusti = "U";
            do
            {
                Console.WriteLine("BLACKJACK");
                
                Kaart[] Pakk = genPakk();
                suffPakk(ref Pakk);

                Mangija mangija = new Mangija();  
                Mangija arvuti = new Mangija();
                
                tKasi(Pakk, ref mangija);
                tKasi(Pakk, ref mangija);

                kontAss(ref mangija);
                opKasi(mangija);
                kontrollPunkt(mangija);

                tKasi(Pakk, ref arvuti);
                tKasi(Pakk, ref arvuti);

                kontAss(ref arvuti);
                opKasi2(arvuti);
                
                bool olemas = true;

            } while (Uusti == "Y");
        }
    }
}
