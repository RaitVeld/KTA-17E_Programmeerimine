using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_kaart
{
    class kaart
    {
        public enum Mast
        {
            Heart,
            Club,
            Spade,
            Dimond
        }

        public enum Vaartus
        {
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        }

        public Mast MyMast { get; set; }
        public Vaartus MyVaartuse { get; set; }
        public int Vaart { get; set; }
    }

    class kaardipakk : kaart
    {
        const int NUM_K = 52;
        private kaart[] pakk;

        public kaardipakk()
        {
            pakk = new kaart[NUM_K];
        }

        public kaart[] GetKaart { get { return pakk; } }

        public void loopakk()
        {
            int i = 0;
            foreach (Mast m in Enum.GetValues(typeof(Mast)))
            {
                foreach (Vaartus v in Enum.GetValues(typeof(Vaartus)))
                {
                    pakk[i] = new kaart { MyMast = m, MyVaartuse = v };
                    i++;
                }
            }

            Suffeldan();
        }

        public void Suffeldan()
        {
            Random lamp = new Random();
            kaart temp;

            for (int sufti = 0; sufti < 100; sufti++)
            {
                for (int i = 0; i<NUM_K; i++)
                {
                    int seckaartIndex = lamp.Next(13);
                    temp = pakk[i];
                    pakk[i] = pakk[seckaartIndex];
                    pakk[seckaartIndex] = temp;
                }
            }
        }

    }
}
