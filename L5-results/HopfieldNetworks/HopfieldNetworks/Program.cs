using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiecHopfield
{
    class Program
    {
        static void Main(string[] args)
        {
            Siec siec = new Siec(3,3);

            double[] tab1 = { 1,1,1, 1, -1, 1, 1, 1, 1};
            List<double> lista1 = new List<double>();
            lista1.AddRange(tab1);

            double[] tab2 = { 1,-1,1,-1,1,-1,1,-1,1 };
            List<double> lista2 = new List<double>();
            lista2.AddRange(tab2);

            double[] tab3 = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            List<double> lista3 = new List<double>();
            lista3.AddRange(tab3);

            double[] tab4 = { 1, -1, 1, 1, -1, 1, 1, 1, 1 };
            List<double> lista4 = new List<double>();
            lista4.AddRange(tab4);

            List<List<double>> listaUczenia = new List<List<double>>();
            listaUczenia.Add(lista1);
            listaUczenia.Add(lista2);
            listaUczenia.Add(lista3);

            siec.Uczenie(listaUczenia);


            List<double> listaWynikowa = siec.Odpytywanie(lista4);

            foreach(var k in listaWynikowa)
            {
                Console.WriteLine(k);
            }

            Console.ReadKey();
        }
    }
}
