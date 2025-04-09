using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiecHopfield
{
    public class Siec
    {
        public List<Neuron> listaNeuronow = new List<Neuron>();
       
        int x, y;

        public Siec(int x, int y)
        {
            this.x = x;
            this.y = y;

            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    listaNeuronow.Add(new Neuron(listaNeuronow, x*y));
                }
            }
        }

        public void Uczenie(List<List<double>> listaWektorow)
        {
            for (int i = 0; i < x*y; i++)
            {
                for (int j = 0; j < x*y; j++)
                {
                    double suma = 0;
                    for(int k = 0; k < listaWektorow.Count; k++)
                    {
                        suma += listaWektorow[k][i] * listaWektorow[k][j];
                    }
                    if(i!=j)
                        listaNeuronow[i].listaWag[j] = 1/(double)(x*y) * suma;
                }
            }
        }

        public List<double> Odpytywanie(List<double> wektorWejsciowy)
        {
            List<double> listaWyjsciowa = new List<double>();

            for(int i = 0; i < listaNeuronow.Count; i++)
            {
                listaNeuronow[i].wyjscie = 0;
                listaNeuronow[i].wejscie = wektorWejsciowy[i];
            }

            int iterator = 0;

            while (iterator<1000)
            {
                for (int i = 0; i < listaNeuronow.Count; i++)
                {
                    listaNeuronow[i].Odpytywanie();
                }

                iterator++;
            }

            for (int i = 0; i < listaNeuronow.Count; i++)
            {
                listaWyjsciowa.Add(listaNeuronow[i].wyjscie);
            }

            return listaWyjsciowa;
        }
    }
}
