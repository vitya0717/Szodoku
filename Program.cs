using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCLI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("feladvanyok.txt");
            List<Feladvany> feladvanyok = new List<Feladvany>();
            List<Feladvany> meretlista = new List<Feladvany>();
            int db = 0;

            foreach (string s in sorok)
            {
                feladvanyok.Add(new Feladvany(s));
            }

            Console.WriteLine($"3. feladat: Beolvasva {feladvanyok.Count} feladvány");

            
            int meret;

            do
            {
                Console.Write($"Kérem a feladvány méretét [4..9]: ");
                meret = int.Parse(Console.ReadLine());

            } while (meret < 4 || meret > 9);

            for (int i = 0; i < feladvanyok.Count; i++)
            {
                if (feladvanyok[i].Meret == meret)
                {
                    db++;
                    meretlista.Add(feladvanyok[i]);

                }
            }
            Console.WriteLine("{0}x{1} Méretű feladványból {2} darab van tárolva.\n", meret, meret, db);

            Random r = new Random();

            int rancsi_szamcsi = r.Next(meret);

            Feladvany kival = meretlista[rancsi_szamcsi];


            Console.WriteLine("5.feladat: A kiválasztott feladvány:\n{0}\n", kival.Kezdo);

            int nulla = 0;
            for (int i = 0; i < kival.Kezdo.Length; i++)
            {
                if (kival.Kezdo[i].ToString() == "0")
                {
                    nulla++;
                }
            }
            double teljes = kival.Kezdo.Length;
            double nulla_nelkul = kival.Kezdo.Length - nulla;

            double hello = nulla_nelkul / teljes * 100;

            Console.WriteLine("6.feladat: A feladvány kitöltöttsége: {0}%\n", Math.Round(hello, 1));

            Console.WriteLine("7.feladat: A feladvány kirajzolva:");
            kival.Kirajzol();
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
