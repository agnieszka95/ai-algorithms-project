using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Neuron
    {
        public double wyjscie = 0;
        List<double> wagi = new List<double>();
        public List<Neuron> wejscia = new List<Neuron>();

        public double w0 = 0;
        public double blad = 1;

        public Neuron(List<Neuron> wejsciaNeuronow)
        {
            wejscia = wejsciaNeuronow;
            Inicjalizacja();
        }


        public void Odpytywanie()
        {
            blad = 0;
            double s = w0;
            for (int i = 0; i < wejscia.Count; i++)
            {
                s += wejscia[i].wyjscie * wagi[i];
            }
           
            wyjscie = FAktywacji(s);
        }

        private double FAktywacji(double x)
        {
            double alfa=1;
            
            return 1.0/(1.0+Math.Exp((-alfa)*x));
        }

        public void Inicjalizacja()
        {
            if (wejscia == null)
            {
                return;
            }
            Random random = new Random();
            for (int i = 0; i < wejscia.Count; i++)
            {
                wagi.Add(random.NextDouble()); //zwraca od 0 do 1
            }

            w0 = random.NextDouble();
        }


        private void UstawienieWag(double n, double d)
        {
            for (int i = 0; i < wagi.Count; i++)
            {
                wagi[i] += n * (d - wyjscie) * wejscia[i].wyjscie;
            }

            w0 += n * (d - wyjscie) * 1;
        }

        private void FunkcjaBledu(double stalaUczenia)
        {
            //reguła Delty
            for (int i = 0; i < wagi.Count; i++)
            {
                wagi[i] += stalaUczenia * (blad) * wejscia[i].wyjscie * PochodnaFunkcjiAktywacji(wyjscie);
            }
            
            w0 += stalaUczenia * (blad) * PochodnaFunkcjiAktywacji(wyjscie);
        }

        private double PochodnaFunkcjiAktywacji(double x)
        {
            return x * (1.0 - x);
        }

        public void Uczenie(double stalaUczenia)
        {
            //miejsce przekazania błędu wyżej, algorytm PB

            for(int i=0;i<wejscia.Count; i++)
            {
                wejscia[i].blad += wagi[i] * blad;
            }

            FunkcjaBledu(stalaUczenia);
        }

        public void Uczenie(double stalaUczenia, double d)
        {
          blad = d - wyjscie;
            //miejsce przekazania błędu wyżej, algorytm PB

            for (int i = 0; i < wejscia.Count; i++)
            {
                wejscia[i].blad += wagi[i] * blad;
            }

            FunkcjaBledu(stalaUczenia);

        }

    }
}
