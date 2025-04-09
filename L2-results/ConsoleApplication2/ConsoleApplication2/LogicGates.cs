using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class BramkiLogiczne
    {
        SiecNeuronowa siecNeuronowa;
        int[] ints = new int [] {2, 3, 1 }; //drugaw wartosc to sieci neuronowe w warstwie ukrytej
        double error=0.01;
        double wynik;
        double counter;
        int counterIteracje=0;

        public BramkiLogiczne()
        {
            siecNeuronowa = new SiecNeuronowa(ints);
        }

        public int uczenieCalosci()
        {
            counterIteracje = 0;
            do
            {
                counter = 0;
                UczenieXOR();


                double[] tab = new double[] {0,0 };
                siecNeuronowa.ustawienieWejscia(tab);
                wynik = siecNeuronowa.Odpytywanie()[0];
                
                wynik = 0 - wynik;
                if (wynik < 0)
                    wynik = -wynik;


                if (wynik < error)
                {
                    counter++;
                }



                tab = new double[] { 0, 1 };
                siecNeuronowa.ustawienieWejscia(tab);
                wynik = siecNeuronowa.Odpytywanie()[0];

                wynik = 1 - wynik;
                if (wynik < 0)
                    wynik = -wynik;


                if (wynik < error)
                {
                    counter++;
                }



                tab = new double[] { 1, 0 };
                siecNeuronowa.ustawienieWejscia(tab);
                wynik = siecNeuronowa.Odpytywanie()[0];

                wynik = 1 - wynik;
                if (wynik < 0)
                    wynik = -wynik;


                if (wynik < error)
                {
                    counter++;
                }



                tab = new double[] { 1, 1 };
                siecNeuronowa.ustawienieWejscia(tab);
                wynik = siecNeuronowa.Odpytywanie()[0];

                wynik = 0 - wynik;
                if (wynik < 0)
                    wynik = -wynik;


                if (wynik < error)
                {
                    counter++;
                }


                counter = counter / 4 * 100;
                counterIteracje++;

            } while (counter<100);

            return counterIteracje;
        }

        public void UczenieXOR()
        {
            double[] tab = new double[] { 0, 0 };
            double[] tabWyjscie = new double[] { 0 };

            siecNeuronowa.ustawienieWejscia(tab);
            
            do
            {
                siecNeuronowa.Uczenie(tabWyjscie);
                wynik = siecNeuronowa.Odpytywanie()[0];

                wynik = tabWyjscie[0] - wynik;
                if (wynik < 0)
                    wynik = -wynik;

            } while (wynik > error);



            tab = new double[] { 0, 1 };
            tabWyjscie = new double[] { 1 };

            siecNeuronowa.ustawienieWejscia(tab);

            do
            {
                siecNeuronowa.Uczenie(tabWyjscie);
                wynik = siecNeuronowa.Odpytywanie()[0];

                wynik = tabWyjscie[0] - wynik;
                if (wynik < 0)
                    wynik = -wynik;

            } while (wynik > error);



            tab = new double[] { 1, 0 };
            tabWyjscie = new double[] { 1 };

            siecNeuronowa.ustawienieWejscia(tab);

            do
            {
                siecNeuronowa.Uczenie(tabWyjscie);
                wynik = siecNeuronowa.Odpytywanie()[0];

                wynik = tabWyjscie[0] - wynik;
                if (wynik < 0)
                    wynik = -wynik;

            } while (wynik > error);



            tab = new double[] { 1, 1 };
            tabWyjscie = new double[] { 0 };

            siecNeuronowa.ustawienieWejscia(tab);

            do
            {
                siecNeuronowa.Uczenie(tabWyjscie);
                wynik = siecNeuronowa.Odpytywanie()[0];

                wynik = tabWyjscie[0] - wynik;
                if (wynik < 0)
                    wynik = -wynik;

            } while (wynik > error);
        }


        public double Odpytywanie(double x1, double x2)
        {
            double[] tab = new double[] { x1, x2 };
            siecNeuronowa.ustawienieWejscia(tab);

            return siecNeuronowa.Odpytywanie()[0];
        }

    }
}
