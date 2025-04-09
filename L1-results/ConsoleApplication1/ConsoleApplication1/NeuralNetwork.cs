using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SiecNeuronowa
    {
        Neuron neuron = new Neuron();
        List<Neuron> wejscioweNeurony = new List<Neuron>();

        public SiecNeuronowa(int iloscWejsc)
        {
            for(int i = 0; i < iloscWejsc; i++)
            {
                wejscioweNeurony.Add(new Neuron());
            }

            neuron.wejscia = wejscioweNeurony;
            neuron.Inicjalizacja(); //oreslilismy agi dla wejsc
        }

        public bool OdpytywanieSieci(double []x)
        {

            for (int i = 0; i < x.Length; i++)
            {
                wejscioweNeurony[i].wyjscie = x[i];
            }
            neuron.Odpytywanie(); //ustawienie wyjscia
            if (neuron.wyjscie == 0) return false;
            else return true;
        }

        public void UczenieNeuronu(double[] x, double wynik, double n)
        {
            for (int i = 0; i < x.Length; i++)
            {
                wejscioweNeurony[i].wyjscie = x[i];
            }
            neuron.Uczenie(n, wynik);
        }
    }
}
