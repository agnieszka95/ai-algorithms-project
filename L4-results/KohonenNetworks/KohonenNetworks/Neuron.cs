using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Neuron
    {
        List<Neuron> wejscia = new List<Neuron>();
        public List<double> wagi = new List<double>();
        public double wyjscie = 0;
        public int x, y;

        public Neuron(List<Neuron> wejsciaNeuronow)
        {
            wejscia = wejsciaNeuronow;
            Inicjalizacja();
        }

        public Neuron(List<Neuron> wejsciaNeuronow, int x, int y)
        {
            wejscia = wejsciaNeuronow;
            Inicjalizacja();
            this.x = x;
            this.y = y;
        }

            static Random random = new Random();


        public void Inicjalizacja()
        {
            if (wejscia == null)
            {
                return;
            }
            for (int i = 0; i < wejscia.Count; i++)
            {
                wagi.Add(random.NextDouble()); //zwraca od 0 do 1
            }
        }

        public double Dystans() //dystans pomiedzy naszym neuronem a szukaną wartością
        {
            double suma = 0;

            for (int i = 0; i < wejscia.Count; i++)
            {
                suma += (wejscia[i].wyjscie - wagi[i]) * (wejscia[i].wyjscie - wagi[i]);
            }

            return Math.Sqrt(suma);
        }

        public void UstawienieWag(double stalaUczenia, double parametrOdleglosci)
        {
            for (int i = 0; i < wagi.Count; i++)
            {
                wagi[i] += stalaUczenia * parametrOdleglosci * (wejscia[i].wyjscie - wagi[i]);
            }
        }

    }
}
