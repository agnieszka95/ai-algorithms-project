using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Neuron
    {
        public double wyjscie = 0;
        List<double> wagi = new List<double>();
        public List<Neuron> wejscia = new List<Neuron>();

        public double w0 = 0;

        public Neuron(List<Neuron> wejsciaNeuronow)
        {
            wejscia = wejsciaNeuronow;
            Inicjalizacja();
        }


        public void Odpytywanie()
        {
            double s = w0;
            for (int i = 0; i < wejscia.Count; i++)
            {
                s += wejscia[i].wyjscie * wagi[i];
            }

            wyjscie = s;
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
                wagi[i] += n * wyjscie * wejscia[i].wyjscie;
            }

            w0 += n * wyjscie * 1;
        }

        public void Uczenie(double stalaUczenia)
        {
            for (int i = 0; i < wagi.Count; i++)
            {
                wagi[i] += stalaUczenia * wyjscie * wejscia[i].wyjscie;
            }

            w0 += stalaUczenia * wyjscie * 1;
        }

        public void UczenieNauczyciel(double stalaUczenia, double d)
        {
            for (int i = 0; i < wagi.Count; i++)
            {
                wagi[i] += stalaUczenia * d * wejscia[i].wyjscie;
            }

            w0 += stalaUczenia * d * 1;
        }
    }
}
