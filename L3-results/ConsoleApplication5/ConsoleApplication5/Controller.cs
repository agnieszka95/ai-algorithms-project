using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Kontroler
    {
        SiecNeuronowa siec;

        public Kontroler()
        {
            int[] tablica = new int[] { 9, 1 };
            siec = new SiecNeuronowa(tablica);
        }

        public double Odpytywanie(double [] tab)
        {
            siec.ustawienieWejscia(tab);
            return siec.Odpytywanie()[0];
        }

        public void Uczenie(double [] wejscia)
        {
            siec.ustawienieWejscia(wejscia);
            siec.Uczenie();
        }

        public void UczenieNauczyciel(double [] wejscia, double d)
        {
            siec.ustawienieWejscia(wejscia);
            siec.UczenieNauczyciel(new double[] { d });
        }
    }
}
