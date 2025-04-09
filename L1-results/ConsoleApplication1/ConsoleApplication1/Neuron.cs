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
        List<double> wagi = new List <double>();
        public List<Neuron> wejscia = new List<Neuron>();

        public double w0 = 0;

        public void Odpytywanie()
        {

            double s = w0;
            for(int i = 0; i < wejscia.Count; i++)
            {
                s += wejscia[i].wyjscie * wagi[i];
            }

            if (FAktywacji(s) < 0) wyjscie = 0;
            else wyjscie = 1;
        }

        private double FAktywacji(double x)
        {
            return x;
        } 

        public void Inicjalizacja()
        {
            Random random = new Random();
            for(int i = 0; i < wejscia.Count; i++)
            {
                wagi.Add(random.NextDouble()); //zwraca od 0 do 1
            }

            w0 = random.NextDouble();
        }

        
        private void UstawienieWag(double n, double d)
        {
            for(int i = 0; i < wagi.Count; i++)
            {
                wagi[i] += n * (d - wyjscie) * wejscia[i].wyjscie;
            }

            w0 += n * (d - wyjscie) * 1;
        }


        public void Uczenie(double n, double d)
        {
            Odpytywanie();
            UstawienieWag(n,d);

        }

    }
}
