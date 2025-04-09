using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BramkiLogiczne
    {
        SiecNeuronowa siecNeuronowa = null;


        public void UczAND(int kolejnePokolenia)
        {
            siecNeuronowa = new SiecNeuronowa(2);
            double[] x1 = new double[] {0,0,1,1 };
            double[] x2 = new double[] { 0, 1, 0, 1 };
            double[] wynik = new double[] { 0, 0, 0, 1 };

            for(int k = 0; k < kolejnePokolenia; k++) { 
                for (int i = 0; i < 4; i++)
                {
                    siecNeuronowa.UczenieNeuronu(new double[] { x1[i], x2[i] }, wynik[i], 1);
                }
            }
        }

        public void UczOR(int kolejnePokolenia)
        {
            siecNeuronowa = new SiecNeuronowa(2);
            double[] x1 = new double[] { 0, 0, 1, 1 };
            double[] x2 = new double[] { 0, 1, 0, 1 };
            double[] wynik = new double[] { 0, 1, 1, 1 };

            for (int k = 0; k < kolejnePokolenia; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    siecNeuronowa.UczenieNeuronu(new double[] { x1[i], x2[i] }, wynik[i], 1);
                }
            }
        }

        public void UczNOT(int kolejnePokolenia)
        {
            siecNeuronowa = new SiecNeuronowa(1);
            double[] x1 = new double[] { 0, 1 };
            double[] wynik = new double[] { 1, 0 };

            for (int k = 0; k < kolejnePokolenia; k++)
            {
                for (int i = 0; i < x1.Length; i++)
                {
                    siecNeuronowa.UczenieNeuronu(new double[] { x1[i]}, wynik[i], 1);
                }
            }
        }

        public bool Pytaj(double []x)
        {
            return siecNeuronowa.OdpytywanieSieci(x);
        }
    }
}
