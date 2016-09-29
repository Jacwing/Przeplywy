using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przeplywy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Graf graf = new Graf(new ElementyGrafu[]
            {
                ElementyGrafu.Jeden,
                ElementyGrafu.Dwa,
                //ElementyGrafu.Trzy,
                ElementyGrafu.Cztery,
                ElementyGrafu.Piec,
                ElementyGrafu.Szesc,
                ElementyGrafu.Siedem,
                ElementyGrafu.Osiem,
                ElementyGrafu.Dziewiec,
                ElementyGrafu.Dziesiec,
                ElementyGrafu.Jedenascie,
                ElementyGrafu.Dwanascie
            });
            foreach (var item in graf.PodajNastepneUłożenieGrafu())
            {
                if ((int)item.ElementyGrafu[4] == 3 + (int)item.ElementyGrafu[1] &
                    (int)item.ElementyGrafu[2] == 3 + (int)item.ElementyGrafu[7] &
                    (int)item.ElementyGrafu[5] == (int)item.ElementyGrafu[1] + (int)item.ElementyGrafu[3] &
                    (int)item.ElementyGrafu[2] == (int)item.ElementyGrafu[3] + (int)item.ElementyGrafu[6] &
                    (int)item.ElementyGrafu[9] == (int)item.ElementyGrafu[5] + (int)item.ElementyGrafu[8] &
                    (int)item.ElementyGrafu[6] == (int)item.ElementyGrafu[8] + (int)item.ElementyGrafu[10] &
                    (int)item.ElementyGrafu[9] == (int)item.ElementyGrafu[11] + (int)item.ElementyGrafu[4] &
                    (int)item.ElementyGrafu[7] == (int)item.ElementyGrafu[10] + (int)item.ElementyGrafu[11])
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("koniec");
            Console.ReadKey();
        }
    }

    public class Graf
    {
        private ElementyGrafu[] elementyGrafu;
        private int dłGrafu;
        private int[] tablicaPomocniczaInt;
        private bool[] tablicaPomocniczaBool;
        private bool pierwszyElement = true;

        public ElementyGrafu[] ElementyGrafu
        {
            get { return elementyGrafu; }
        }

        public Graf(ElementyGrafu[] elementyGrafu)
        {
            dłGrafu = elementyGrafu.Length;
            this.elementyGrafu = new ElementyGrafu[dłGrafu + 1];
            tablicaPomocniczaInt = new int[dłGrafu + 1];
            tablicaPomocniczaBool = new bool[dłGrafu + 1];
            for (int i = 1; i <= dłGrafu; i++)
            {
                this.elementyGrafu[i] = elementyGrafu[i - 1];
                tablicaPomocniczaInt[i] = 1;
                tablicaPomocniczaBool[i] = true;
            }
            tablicaPomocniczaInt[dłGrafu] = 0;
        }


        public IEnumerable<Graf> PodajNastepneUłożenieGrafu()
        {
            if (pierwszyElement)
            {
                yield return this;
                pierwszyElement = false;
            }
            for (;;)
            {
                int i = 1, x = 0;
                while (tablicaPomocniczaInt[i] == dłGrafu - i + 1)
                {
                    tablicaPomocniczaBool[i] = !tablicaPomocniczaBool[i];
                    tablicaPomocniczaInt[i] = 1;
                    if (tablicaPomocniczaBool[i])
                        ++x;
                    ++i;
                }
                if (i >= dłGrafu)
                    yield break;
                int k;
                if (tablicaPomocniczaBool[i])
                    k = tablicaPomocniczaInt[i] + x;
                else
                    k = dłGrafu - i + 1 - tablicaPomocniczaInt[i] + x;
                ElementyGrafu temp = elementyGrafu[k];
                elementyGrafu[k] = elementyGrafu[k + 1];
                elementyGrafu[k + 1] = temp;
                yield return this;
                ++tablicaPomocniczaInt[i];
            }
        }

        public override string ToString()
        {
            string wynik = null;
            for (int i = 1; i <= dłGrafu; i++)
            {
                wynik = wynik + ((int)elementyGrafu[i]).ToString() + ", ";
            }
            return wynik;
        }
    }

    public enum ElementyGrafu
    {
        Jeden = 1,
        Dwa = 2,
        Trzy = 3,
        Cztery = 4,
        Piec = 5,
        Szesc = 6,
        Siedem = 7,
        Osiem = 8,
        Dziewiec = 9,
        Dziesiec = 10,
        Jedenascie = 11,
        Dwanascie = 12
    }
}
