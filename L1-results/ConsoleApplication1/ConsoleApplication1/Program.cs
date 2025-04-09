using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BramkiLogiczne bramka = new BramkiLogiczne();

            ////dla AND
            //bramka.UczOR(5);
            //double[] x1 = new double[] { 0, 0, 1, 1 };
            //double[] x2 = new double[] { 0, 1, 0, 1 };

            //for (int i = 0; i < x1.Length; i++)
            //{
            //    Console.WriteLine(bramka.Pytaj(new double[] { x1[i], x2[i] }));
            //}



            //DLA NOT
            bramka.UczNOT(5);
            double[] x1 = new double[] { 0, 1 };

            for (int i = 0; i < x1.Length; i++)
            {
                Console.WriteLine(bramka.Pytaj(new double[] { x1[i] } ));
            }
            
            Console.ReadLine();
        }

        
    }
}
