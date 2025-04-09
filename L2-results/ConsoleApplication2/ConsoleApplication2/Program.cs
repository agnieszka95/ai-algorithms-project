using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static BramkiLogiczne bramka;

        static void Wypisywanie()
        {
            Console.WriteLine( bramka.Odpytywanie(0, 0));
            Console.WriteLine(bramka.Odpytywanie(0, 1));
            Console.WriteLine(bramka.Odpytywanie(1, 0));
            Console.WriteLine(bramka.Odpytywanie(1, 1));
        }

        static void Main(string[] args)
        {
            bramka = new BramkiLogiczne();
            Wypisywanie();
            Console.WriteLine(bramka.uczenieCalosci());
            Wypisywanie();

            Console.ReadLine();
        }
    }
}
