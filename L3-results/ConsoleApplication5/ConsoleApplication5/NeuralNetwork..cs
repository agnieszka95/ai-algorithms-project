using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class SiecNeuronowa
    {
        List<List<Neuron>> siecNeuronowa = new List<List<Neuron>>();
        double stalaUczenia = 0.6;


        public SiecNeuronowa(int[] tab)
        {
            List<Neuron> poprzedniaLista = null;

            for (int i = 0; i < tab.Length; i++)
            {
                List<Neuron> listaNeuronow = new List<Neuron>();

                for (int j = 0; j < tab[i]; j++)
                {
                    listaNeuronow.Add(new Neuron(poprzedniaLista));

                }
                poprzedniaLista = listaNeuronow;
                siecNeuronowa.Add(listaNeuronow);
            }
        }

        public void ustawienieWejscia(double[] tab)
        {
            int counter = 0;

            foreach (Neuron neuron in siecNeuronowa.First())
            {
                neuron.wyjscie = tab[counter++];
            }
        }

        public double[] Odpytywanie()
        {
            double[] tab = new double[siecNeuronowa.Last().Count];

            for (int i = 1; i < siecNeuronowa.Count; i++)
            {
                foreach (Neuron neuron in siecNeuronowa[i])
                {
                    neuron.Odpytywanie();
                }
            }

            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = siecNeuronowa.Last()[i].wyjscie;
            }

            return tab;
        }

        public void Uczenie()
        {
            Odpytywanie();
            
            for (int i = 1; i < siecNeuronowa.Count; i++)
            {
                foreach (Neuron neuron in siecNeuronowa[i])
                {
                    neuron.Uczenie(stalaUczenia);
                }
            }
        }

        public void UczenieNauczyciel(double[] tab)
        {
            Odpytywanie();
            int counter = 0;

            foreach (Neuron neuron in siecNeuronowa.Last())
                {
                    neuron.UczenieNauczyciel(stalaUczenia, tab[counter++]);
                }
        }

    }
}
