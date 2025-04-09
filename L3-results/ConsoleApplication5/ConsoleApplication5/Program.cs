using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Kontroler kontroler = new Kontroler();

            //double[] tab1 = new double[] {1,-1,1,-1,-1,-1,1,-1,1 };
            //double[] tab2 = new double[] { -1,1,-1,1,-1,1,1,-1,1 };

            double[] tab1 = new double[] { -1,1,-1,1,1,1,-1,1,-1};
            double[] tab2 = new double[] { 1,1,1,1,-1,1,1,1,1};


            Console.WriteLine("Dla tab1: " + kontroler.Odpytywanie(tab1));
            Console.WriteLine("Dla tab2: " + kontroler.Odpytywanie(tab2));

            for(int i = 0; i < 10; i++)
            {
                kontroler.UczenieNauczyciel(tab1, -1);
                kontroler.UczenieNauczyciel(tab2, 1);
            }

            Console.WriteLine("Po uczeniu z nauczycielem tab1: " + kontroler.Odpytywanie(tab1));
            Console.WriteLine("Po uczeniu z nauczycielem tab2: " + kontroler.Odpytywanie(tab2));




            Kontroler kontroler2 = new Kontroler();
            Console.WriteLine("Dla tab1: " + kontroler2.Odpytywanie(tab1));
            Console.WriteLine("Dla tab2: " + kontroler2.Odpytywanie(tab2));

            for (int i = 0; i < 10; i++)
            {
                kontroler2.Uczenie(tab1);
                kontroler2.Uczenie(tab2);
            }

            Console.WriteLine("Po uczeniu bez nauczycielem tab1: " + kontroler2.Odpytywanie(tab1));
            Console.WriteLine("Po uczeniu bez nauczycielem tab2: " + kontroler2.Odpytywanie(tab2));

            Console.ReadLine();

        }
    }
}
