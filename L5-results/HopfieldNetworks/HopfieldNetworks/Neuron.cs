using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiecHopfield
{
    public class Neuron
    {
        public double wejscie, wyjscie;
        public List<Neuron> listaNeuronow;
        public List<double> listaWag;

        public Neuron(List<Neuron> listaNeuronow, int iloscNeuronow)
        {
            this.listaNeuronow = listaNeuronow;

            listaWag = new List<double>();
            for(int i = 0; i < iloscNeuronow; i++)
            {
                listaWag.Add(0);
            }
        }

        public void Odpytywanie()
        {
            double wynik=0;
            for(int i = 0; i < listaNeuronow.Count; i++)
            {
                wynik += listaWag[i] * listaNeuronow[i].wyjscie;
            }

            wynik += wejscie;

            if (wynik > 0)
            {
                wyjscie = 1;
            }

            else if (wynik < 0)
            {
                wyjscie = -1;
            }
        }
        
    }
}
