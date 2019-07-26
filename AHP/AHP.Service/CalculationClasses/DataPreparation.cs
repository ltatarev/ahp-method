using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Service.CalculationClasses
{
    public class DataPreparation
    {



        #region methods
        public double[] NormalizeVector(double[] vector)
        {
            /// <summary>
            /// Method for normalizing vector.
            /// </summary>
            /// <param name="vector">Input vector that needs to be normalized</param>
            /// <returns>
            /// Normalized vector.
            /// </returns>

            int len = vector.Length;
            double sum = 0;

            double[] NormalizedVector = new double[len];

            for (int i = 0; i < len; i++)
            {
                sum += vector[i];
            }

            for (int i = 0; i < len; i++)
            {
                NormalizedVector[i] = vector[i] / sum;
            }

            return NormalizedVector;
        }  //posebna klasa
        #endregion methods

       

    }
}
