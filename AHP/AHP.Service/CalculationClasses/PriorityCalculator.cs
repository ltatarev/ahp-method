using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.CalculationClasses
{
    public class PriorityCalculator
    {
        public double[] CalculatePriority(double[,] Matrix)
        {
            /// <summary>
            /// Method for calculating priorities of given parameters (criterion or alternatives).
            /// </summary>
            /// <param name="Matrix">Square parameter matrix.</param>
            /// <returns>
            /// Array of priorities.
            /// </returns>

            // Matrix size
            int len = Matrix.GetLength(0);

            // Array of geometric means
            double[] GeoMeans = new double[len];

            double sum = 0;
            for (int i = 0; i < len; i++)
            {
                double prod = 1;
                for (int j = 0; j < len; j++)
                {
                    prod *= Matrix[i, j];
                }
                GeoMeans[i] = Math.Pow(prod, (1 / (float)len));
                sum += GeoMeans[i];
            }

            return (GeoMeans);  //normalize should be called after
        }         //posebna klasa
    }
}
