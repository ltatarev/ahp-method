using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service
{
    public class Service
    {
        public double[,] KreiranjeMatrice(int[] polje, int dimenzija)
        {
            /// <summary>
            /// Metoda za kreiranje matrice od prosljeđenih elemenata gornjeg trokuta matrice.
            /// Vrijednost elemenata na dijagonali je 1, a ispod dijagonale se nalaze recipročne vrijednosti
            /// elemenata gornjeg trokuta.
            /// </summary>
            /// <param name="polje">Polje elemenata od kojeg konstruiramo matricu.</param>
            /// <param name="dimenzija">Dimenzija matrice</param>
            /// <returns>
            /// Matricu veličine dimenzija x dimenzija.
            /// </returns>

            int d = dimenzija;

            double[,] Matrica = new double[dimenzija, dimenzija];

            if (polje.Length == (d * d - d) / 2)
            {
                for (int i = 0; i < d; i++)
                {
                    Matrica[i, i] = 1;
                    for (int j = 0; j < d; j++)
                    {
                        int k = 0;
                        if (j > i)
                        {
                            Matrica[i, j] = polje[k];
                            k++;
                            Matrica[j, i] = 1 / Matrica[i, j];
                        }
                    }
                }
                return Matrica;
            }
            else
            {
                return null;
            }
        }

        public double[] IzracunPrioriteta(double[,] Matrica)
        {
            /// <summary>
            /// Metoda za izračun prioriteta parametara koristeći geometrijsku sredinu redova matrice.
            /// </summary>
            /// <param name="Matrica">Kvadratna matrica parametara kojoj računamo prioritete.</param>
            /// <returns>
            /// Polje prioriteta parametra.
            /// </returns>

            // veličina prosljeđene matrice
            int len = Matrica.GetLength(0);

            // Polje geometrijskih sredina
            double[] GS = new double[len];

            // Polje prioriteta (normirano polje geometrijskih sredina)
            double[] Prioritet = new double[len];

            double sum = 0;

            for (int i = 0; i < len; i++)
            {
                double prod = 1;
                for (int j = 0; j < len; j++)
                {
                    prod *= Matrica[i, j];
                }
                GS[i] = Math.Pow(prod, (1 / len));
                sum += GS[i];
            }

            // Normiranje vektora GS
            for (int i = 0; i < len; i++)
            {
                GS[i] = GS[i] / sum;
            }

            return Prioritet;
        }

        public void KonacniPoredak(int m, int n)
        {
            /// <summary>
            /// Metoda za izračun konačnog poretka alternativa.
            /// </summary>
            /// <param name="m">Broj kriterija</param>
            /// <param name="n">Broj alternativa</param>
            /// <returns>
            /// Polje prioriteta alternativa.
            /// </returns>

            ///////////// Poredak kriterija
            // Polje preferenca kriterija iz baze RangKriterija. (gornji trokut matrice)
            int[] Kriterij = new int[(m * m - m) / 2];

            double[] PrioritetKriterija = new double[m];
            PrioritetKriterija = IzracunPrioriteta(KreiranjeMatrice(Kriterij, m));

            ///////////// Prioritet alternativa za sve kriterije
            // Matrica prioriteta alternativa u odnosu na kriterij
            double[,] W = new double[n, m];

            for (int i = 0; i < m; i++)
            {
                // dohvatiti polje preferenca alternativa iz baze RangAlternativa uz uvjet kriterij == i
                int[] Alternative = new int[(n * n - n) / 2];

                // Prioritet svih alternativa u odnosu na i-ti kriterij
                double[] PrioritetAlternative = IzracunPrioriteta(KreiranjeMatrice(Alternative, n));

                for (int j = 0; j < m; j++)
                {
                    // Kriteriji iteriraju po stupcima, rezultate spremamo u i-ti stupac matrice W
                    W[j, i] = PrioritetAlternative[j];
                }
            }

            // Konačni poredak
            double[] KonacniPoredakAlt = new double[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    KonacniPoredakAlt[i] = W[i, j] * PrioritetKriterija[j];
                }
            }

            // spremanje vektora KonacniPoredakAlt u bazu Rezultat

            return;
        }

    }
}


