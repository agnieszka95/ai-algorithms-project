using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApplication6
{
    class Siec
    {
        List<Neuron> wejscia = new List<Neuron>();
        List<Neuron> mapaNeuronow = new List<Neuron>();
        int x, y;

        public Siec(int szerokosc, int wysokosc)//3 neurony wejsciowe
        {
            x = szerokosc;
            y = wysokosc;

            for (int i = 0; i < 3; i++)
            {
                wejscia.Add(new Neuron(null));
            }

            for (int y = 0; y < wysokosc; y++)
            {
                for (int x = 0; x < szerokosc; x++)
                {
                    mapaNeuronow.Add(new Neuron(wejscia, x, y));

                }
            }
        }

        private double[] Normalizacja(int[] tab)
        {
            double[] zwrot = new double[tab.Length];

            for (int i = 0; i < tab.Length; i++)
            {
                zwrot[i] = (double)tab[i] / 255.0;
            }

            return zwrot;
        }

        private int[] Konwersja(double[] tab)
        {
            int[] zwrot = new int[tab.Length];

            for (int i = 0; i < tab.Length; i++)
            {
                zwrot[i] = (int)(tab[i] * 255.0);

                if (zwrot[i] > 255)
                {
                    zwrot[i] = 255;
                }
            }
            return zwrot;
        }

        public Neuron getNeuron(int xx, int yy)
        {
            return mapaNeuronow[yy*x+xx];
        }

        public Bitmap Odpytywanie() //pytamy kazdy neron w mapie, im mniejszy dystans tym barwa mocniejsza
        {
            Bitmap mapa = new Bitmap(x,y);

            for(int yy = 0; yy < y; yy++)
            {
                for(int xx = 0; xx < x; xx++)
                {
                    double tmp = getNeuron(xx, yy).Dystans();
                    int r, g, b;
                    r = Konwersja(new double[] { tmp })[0];
                    g = Konwersja(new double[] { tmp })[0];
                    b = Konwersja(new double[] { tmp })[0];

                    Color kolor = Color.FromArgb(r,g,b);
                    mapa.SetPixel(xx,yy,kolor);
                }
            }
            return mapa;
        }

        public Bitmap AktualnaMapa()
        {
            Bitmap mapa = new Bitmap(x, y);

            for (int yy = 0; yy < y; yy++)
            {
                for (int xx = 0; xx < x; xx++)
                {
                    double[] tmp = getNeuron(xx, yy).wagi.ToArray();
                    int[] rgb = Konwersja(tmp);

                    Color kolor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    mapa.SetPixel(xx, yy, kolor);
                }
            }
            return mapa;
        }

        List<double[]> tab;
        int iloscIteracji, aktualnaIteracja;
        double promienPola, stalaCzasowa, stalaUczeniaGlobalna;

        public void Start(List<Color> kolory, int iloscIteracji)
        {
            stalaUczeniaGlobalna = 0.6;
            this.iloscIteracji = iloscIteracji;
            aktualnaIteracja = iloscIteracji;
            tab = new List<double[]>();
            promienPola = (double)Math.Max(x, y)/2.0;
            stalaCzasowa = iloscIteracji / Math.Log(promienPola);

            foreach(Color tmp in kolory)
            {
                tab.Add(Normalizacja(new int[] { tmp.R, tmp.G, tmp.B }));
            }
        }

        public void ustawienieWejscia(double[] tab)
        {
            for(int i = 0; i < wejscia.Count; i++)
            {
                wejscia[i].wyjscie = tab[i];
            }
        }

        public Neuron najblizszaBarwa()
        {
            double minimalnaWartosc = double.MaxValue;
            int minimalnyIndeks = 5;

            for(int i = 0; i < mapaNeuronow.Count; i++)
            {
                double tmp = mapaNeuronow[i].Dystans();

                if (tmp < minimalnaWartosc)
                {
                    minimalnaWartosc = tmp;
                    minimalnyIndeks = i;
                }
                
            }
            return mapaNeuronow[minimalnyIndeks];
        }

        public Bitmap odpytanieSieci(Color kolor)
        {
            double[] tab = Normalizacja(new int[] { kolor.R, kolor.G, kolor.B});
            ustawienieWejscia(tab);
            return Odpytywanie();
        }

        public void Epoka()
        {
            if (aktualnaIteracja > 0)
            {
                Random random = new Random();

                int randomInt = random.Next(0,tab.Count);

                double[] wybranaBarwa = tab[randomInt];
                ustawienieWejscia(wybranaBarwa);

                Neuron minimalny = najblizszaBarwa();

                foreach(Neuron aktualnyNeuron in mapaNeuronow)
                {
                    double dystans = Math.Sqrt(((aktualnyNeuron.x - minimalny.x)* (aktualnyNeuron.x - minimalny.x) +(aktualnyNeuron.y - minimalny.y) * (aktualnyNeuron.y - minimalny.y)));
                    double zmiennaSasiadow = promienPola * Math.Exp(-(double)(iloscIteracji - aktualnaIteracja) / stalaCzasowa);
                    double parametrOdleglosci = Math.Exp(-(dystans * dystans) / (2 * zmiennaSasiadow * zmiennaSasiadow));
                    double stalaUczenia = stalaUczeniaGlobalna * Math.Exp(-(double)(iloscIteracji - aktualnaIteracja) / iloscIteracji);
                    if (dystans < zmiennaSasiadow)
                    {
                        aktualnyNeuron.UstawienieWag(stalaUczenia,parametrOdleglosci);
                    }
                }

                aktualnaIteracja--;
            }
        }

    }
}
