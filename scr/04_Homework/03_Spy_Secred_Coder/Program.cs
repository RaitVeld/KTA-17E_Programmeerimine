using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Spy_Secred_Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programm muudab mingisuguse lause salakoodiks. Ning muudab salakoodi tagasi algseks lausesks. Õppisin kasutama switch ja StringBuilder funktsioone.
            Console.WriteLine("Tere spioon! See on sinu tööriist, et kirjutada salakoode ning tõlkida neid. Vastased ei tohi teada teksti sisu!");
            Console.WriteLine("Kas sa soovid muuta teksti koodiks või tõlkida kood tekstiks");
            Console.WriteLine("1.Kood");
            Console.WriteLine("2.Tõlk");
            int vali;
            int.TryParse(Console.ReadLine(), out vali);

            switch (vali)
            {
                case 1:
                    Console.WriteLine("Sisesta tekst mida soovid salastada!");
                    string tk1 = Console.ReadLine();
                    StringBuilder tk2 = new StringBuilder(tk1);

                    tk2.Replace("k", "+");
                    tk2.Replace("l", "k");
                    tk2.Replace("ö", "l");
                    tk2.Replace("m", "ö");
                    tk2.Replace("ä", "m");
                    tk2.Replace("h", "ä");
                    tk2.Replace("ü", "h");
                    tk2.Replace("2", "ü");
                    tk2.Replace("õ", "2");
                    tk2.Replace("9", "õ");
                    tk2.Replace("i", "9");
                    tk2.Replace("5", "i");
                    tk2.Replace("e", "5");
                    tk2.Replace("0", "e");
                    tk2.Replace("a", "0");
                    
                    Console.WriteLine(tk2);

                    break;

                case 2:
                    Console.WriteLine("Sisesta kood mida soovid tõlkida!");
                    string kt1 = Console.ReadLine();
                    StringBuilder kt2 = new StringBuilder(kt1);

                    kt2.Replace("0", "a");
                    kt2.Replace("e", "0");
                    kt2.Replace("5", "e");
                    kt2.Replace("i", "5");
                    kt2.Replace("9", "i");
                    kt2.Replace("õ", "9");
                    kt2.Replace("2", "õ");
                    kt2.Replace("ü", "2");
                    kt2.Replace("h", "ü");
                    kt2.Replace("ä", "h");
                    kt2.Replace("m", "ä");
                    kt2.Replace("ö", "m");
                    kt2.Replace("l", "ö");
                    kt2.Replace("k", "l");
                    kt2.Replace("+", "k");
                    
                    Console.WriteLine(kt2);

                    break;

                default:
                    Console.WriteLine("Vastased leidsid su, PÕGENE!!!!");
                    break;                          

            }

            Console.WriteLine("Programmi lõpp. Turvalisuse mõttes pange oma arvuti palun põlema. Head õhtud Agent Spioon!");
            Console.ReadLine();
        }
    }
}
