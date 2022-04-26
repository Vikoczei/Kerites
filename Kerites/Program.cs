using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kerites
{
    class Program
    {

        class Telek
        {
            public string paritas;
            public int szelesseg;
            public string szin;
            public int hazszam;

            public static int paros = 0;
            public static int paratlan = -1;


            public static List<Telek> lista = new List<Telek>();
            public static List<Telek> paros_lista = new List<Telek>();
            public static List<Telek> paratlan_lista = new List<Telek>();


            public Telek(string[] sortomb)
            {
                this.paritas = sortomb[0];
                this.szelesseg = int.Parse(sortomb[1]);
                this.szin = sortomb[2];

                if (sortomb[0] == "0")
                {
                    this.hazszam = paros + 2;
                    paros += 2;
                    Telek.paros_lista.Add(this);
                }

                else
                {
                    this.hazszam = paratlan + 2;
                    paratlan += 2;
                    Telek.paratlan_lista.Add(this);
                }
            }
        }

        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("kerites.txt", Encoding.UTF8);

           

            foreach (string sor in sorok)
            {
                string[] sortomb = sor.Split(' ');
                new Telek(sortomb);
            }


            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Az eladott telkek száma: {Telek.lista.Count}");

            Console.ReadKey();
        }
    }
}
